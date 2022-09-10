using MySUS.HTTP;
using System.Collections.Generic;

namespace MySUS.MvcFramework
{
    public interface IMvcApplication
    {
        void ConfigureServices(IServiceCollection serviceCollection);

        void Configure(ICollection<Route> routeTable);
    }
}
