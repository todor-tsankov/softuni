using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;

using MySUS.HTTP;
using System.IO;
using System.Text.RegularExpressions;

namespace MySUS.MvcFramework
{
    public static class Host
    {
        public static async Task CreateHostAsync<T>(int port = 80)
            where T : IMvcApplication
        {
            var type = typeof(T);
            var application = (IMvcApplication)Activator.CreateInstance(type);

            var routeTable = new List<Route>();
            var serviceCollection = new ServiceCollection();

            application.ConfigureServices(serviceCollection);
            application.Configure(routeTable);

            AddStaticFiles(type, routeTable);
            AddControllers(type, routeTable, serviceCollection);

            var server = new HttpServer(routeTable);
            await server.StartAsync(port);
        }

        private static void AddControllers(Type type, ICollection<Route> routeTable, IServiceCollection serviceCollection)
        {
            var controllerTypes = type.Assembly
                            .GetTypes()
                            .Where(x => x.BaseType == typeof(Controller))
                            .ToArray();

            foreach (var controllerType in controllerTypes)
            {
                var methodInfos = controllerType
                    .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                    .Where(x => !x.IsConstructor && !x.IsSpecialName && x.DeclaringType == controllerType)
                    .ToArray();

                foreach (var methodInfo in methodInfos)
                {
                    var customAttribute = methodInfo
                        .GetCustomAttributes()
                        .FirstOrDefault((x => x.GetType().BaseType == typeof(HttpMethodAttribute)));

                    var path = $"/{controllerType.Name.Replace("Controller", string.Empty).ToLowerInvariant()}/{methodInfo.Name.ToLowerInvariant()}";
                    var method = HttpMethod.GET;

                    if (customAttribute != null)
                    {
                        var httpMethodAttribute = customAttribute as HttpMethodAttribute;

                        if (httpMethodAttribute.GetType() == typeof(HttpPostMethod))
                        {
                            method = HttpMethod.POST;
                        }

                        if (httpMethodAttribute.Path != null)
                        {
                            path = httpMethodAttribute.Path;
                        }
                    }

                    Func<HttpRequest, HttpResponse> action = request =>
                    {
                        return ExecuteMethod(request, controllerType, methodInfo, serviceCollection);
                    };

                    var route = new Route(path, method, action);
                    routeTable.Add(route);
                }
            }
        }

        private static HttpResponse ExecuteMethod(HttpRequest request, Type controllerType, MethodInfo methodInfo, IServiceCollection serviceCollection)
        {
            var controllerInstance = serviceCollection.CreateInstance(controllerType) as Controller;
            controllerInstance.httpRequest = request;

            var methodArguments = new List<object>();
            var methodParameters = methodInfo.GetParameters();

            foreach (var parameter in methodParameters)
            {
                var converted = Convert.ChangeType(GetParameterFromRequest(request, parameter.Name), parameter.ParameterType);

                if (converted == null && parameter.ParameterType != typeof(string) && parameter.ParameterType != typeof(int?))
                {
                    var properties = parameter.ParameterType.GetProperties();
                    var complexInstance = Activator.CreateInstance(parameter.ParameterType);

                    foreach (var property in properties)
                    {
                        var value = GetParameterFromRequest(request, property.Name);
                        converted = Convert.ChangeType(value, property.PropertyType);

                        property.SetValue(complexInstance, converted);
                    }

                    converted = complexInstance;
                }

                methodArguments.Add(converted);
            }

            return methodInfo.Invoke(controllerInstance, methodArguments.ToArray()) as HttpResponse;
        }

        private static string GetParameterFromRequest(HttpRequest httpRequest, string name)
        {
            name = name.ToLowerInvariant();

            if (httpRequest.FormData.ContainsKey(name))
            {
                return httpRequest.FormData[name];
            }

            if (httpRequest.QueryData.ContainsKey(name))
            {
                return httpRequest.QueryData[name];
            }

            return null;
        }

        private static void AddStaticFiles(Type type, ICollection<Route> routeTable)
        {
            var filePaths = Directory.GetFiles("wwwroot", "*", SearchOption.AllDirectories);

            foreach (var filePath in filePaths)
            {
                var body = File.ReadAllBytes(filePath);
                var path = filePath
                    .Replace("wwwroot", string.Empty)
                    .Replace("\\", "/")
                    .ToLowerInvariant();

                var method = HttpMethod.GET;
                var fileExt = new FileInfo(filePath).Extension;

                var contentType = fileExt switch
                {
                    ".txt" => "text/plain",
                    ".js" => "text/javascript",
                    ".css" => "text/css",
                    ".jpg" => "image/jpg",
                    ".jpeg" => "image/jpg",
                    ".png" => "image/png",
                    ".gif" => "image/gif",
                    ".ico" => "image/vnd.microsoft.icon",
                    ".html" => "text/html",
                    _ => "text/plain",
                };

                Func<HttpRequest, HttpResponse> action = request =>
                {
                    return new HttpResponse(contentType, body);
                };

                var route = new Route(path, method, action);
                routeTable.Add(route);
            }
        }
    }
}
