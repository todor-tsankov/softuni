using System;
using Xunit;

using System.IO;
using MySUS.MvcFramework.ViewEngine;

namespace MySUS.MvcFramework.Tests
{
    public class ViewEngineTests
    {
        [Theory]
        [InlineData("WithoutAnyCode")]
        [InlineData("IfAndFor")]
        [InlineData("ForeachWithModel")]
        [InlineData("Complexcase")]
        public void ViewEngineTest(string fileName)
        {
            var viewEngine = new MySusViewEngine();

            var htmlTemplate = File.ReadAllText($"TestViews/{fileName}.html");
            var actualResult = viewEngine.GenerateHtml(htmlTemplate, new TestViewModel(), null);

            var expectedResult = File.ReadAllText($"TestViews/{fileName}.Expected.html");

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
