using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using MySUS.HTTP;
using MySUS.MvcFramework;
using TestApp.Controllers;

namespace TestApp
{
    public class StartUp : IMvcApplication
    {
        public void Configure(ICollection<Route> routeTable)
        {
        }


        public void ConfigureServices(IServiceCollection serviceCollection)
        {
        }
    }
}
