using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace MySUS.MvcFramework.ViewEngine
{
    public class MySusViewEngine : IViewEngine
    {
        private const string Ampersat = "@";
        private const string OpeningBracket = "{";
        private const string ClosingBracket = "}";
        private const string SingleQuotationMark = "\"";
        private const string EscapedSingleQuotationMark = "\\\"";

        private const string Regex = @"@(([\w\.[\]]+)|(\(.*\)))";

        private const string GenericsFormat = "<{0}>";
        private const string SbAppendLineFormat = "sb.AppendLine(\"{0}\");";

        private const string TemplateReplace = "//Replace";
        private const string TemplateClassPath = "ViewEngine/ViewClass.txt";


        public string GenerateHtml(string htmlTemplate, object viewModel, string user)
        {
            var cSharpCode = this.GenerateCSharpCode(htmlTemplate, viewModel);
            var view = this.CreateView(cSharpCode, viewModel);

            return view.Execute(viewModel, user);
        }

        private string GenerateCSharpCode(string htmlTemplate, object viewModel)
        {
            var cSharpBuilder = new StringBuilder();

            if (viewModel != null)
            {
                var viewModelType = viewModel.GetType();
                var modelTypeName = viewModelType.FullName;

                if (viewModelType.IsGenericType)
                {
                    var index = modelTypeName.IndexOf("`");

                    var genericArgs = viewModelType
                        .GetGenericArguments()
                        .Select(x => x.FullName);

                    var genericsString = string.Format(GenericsFormat, string.Join(",", genericArgs));

                    modelTypeName = modelTypeName.Substring(0, index) + genericsString;
                }

                cSharpBuilder.AppendLine($"var Model = viewModel as {modelTypeName};");
            }

            var classTemplate = File.ReadAllText(TemplateClassPath);
            using var reader = new StringReader(htmlTemplate);

            while (true)
            {
                var currentLine = reader.ReadLine();

                if (currentLine == null)
                {
                    break;
                }

                var trimmed = currentLine.TrimStart();

                if (trimmed.StartsWith(Ampersat) || trimmed.StartsWith(OpeningBracket) || trimmed.StartsWith(ClosingBracket))
                {
                    cSharpBuilder.AppendLine(currentLine.Replace(Ampersat, string.Empty));
                }
                else if (trimmed.Contains(Ampersat))
                {
                    currentLine = currentLine.Replace(SingleQuotationMark, EscapedSingleQuotationMark);

                    var regex = new Regex(Regex);
                    var matches = regex.Matches(currentLine);

                    foreach (var match in matches)
                    {
                        currentLine = currentLine.Replace(match.ToString(), $"{SingleQuotationMark} + {match.ToString().Replace(Ampersat, string.Empty)} + {SingleQuotationMark}");
                    }

                    var formattedString = string.Format(SbAppendLineFormat, currentLine);
                    cSharpBuilder.AppendLine(formattedString);
                }
                else
                {
                    currentLine = currentLine.Replace(SingleQuotationMark, EscapedSingleQuotationMark);

                    var formattedString = string.Format(SbAppendLineFormat, currentLine);
                    cSharpBuilder.AppendLine(formattedString);
                }
            }

            var cSharpCode = cSharpBuilder.ToString().TrimEnd();
            var completeClass = classTemplate.Replace(TemplateReplace, cSharpCode);

            return completeClass;
        }

        private IView CreateView(string csharpCode, object viewModel)
        {
            var options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);
            var references = new List<MetadataReference>();

            var coreClrRef = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
            var iViewRef = MetadataReference.CreateFromFile(typeof(IView).Assembly.Location);

            references.Add(coreClrRef);
            references.Add(iViewRef);

            if (viewModel != null)
            {
                var viewModelType = viewModel.GetType();
                var viewModelRef = MetadataReference.CreateFromFile(viewModelType.Assembly.Location);

                references.Add(viewModelRef);

                if (viewModelType.IsGenericType)
                {
                    var genericArgs = viewModelType.GetGenericArguments();

                    foreach (var genericArg in genericArgs)
                    {
                        var genericRef = MetadataReference.CreateFromFile(genericArg.Assembly.Location);

                        references.Add(genericRef);
                    }
                }

            }

            var netStandartAssemblyName = new AssemblyName("netstandard");
            var assemblyNames = Assembly.Load(netStandartAssemblyName)
                .GetReferencedAssemblies();

            foreach (var name in assemblyNames)
            {
                var assembly = Assembly.Load(name);
                var reference = MetadataReference.CreateFromFile(assembly.Location);

                references.Add(reference);
            }

            var syntaxTree = SyntaxFactory.ParseSyntaxTree(csharpCode);

            var compileResult = CSharpCompilation.Create("ViewAssembly")
                .WithOptions(options)
                .WithReferences(references)
                .AddSyntaxTrees(syntaxTree);

            using var memoryStream = new MemoryStream();
            var result = compileResult.Emit(memoryStream);

            if (!result.Success)
            {
                var errorMessages = result.Diagnostics
                    .Where(x => x.Severity == DiagnosticSeverity.Error)
                    .Select(x => x.GetMessage());

                return new ErrorView(errorMessages, csharpCode);
            }

            try
            {
                memoryStream.Seek(0, SeekOrigin.Begin);

                var byteAssembly = memoryStream.ToArray();
                var assembly = Assembly.Load(byteAssembly);

                var type = assembly.GetType("ViewNamespace.ViewClass");
                var instance = Activator.CreateInstance(type) as IView;

                if (instance == null)
                {
                    return ReturnErrorView(csharpCode, "Instance is Null!");
                }

                return instance;
            }
            catch (Exception e)
            {
                return ReturnErrorView(csharpCode, e.Message);
            }
        }

        private static IView ReturnErrorView(string csharpCode, params string[] messages)
        {
            return new ErrorView(messages, csharpCode);
        }
    }
}