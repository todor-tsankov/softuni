using System;

namespace MySUS.MvcFramework
{
    public interface IServiceCollection
    {
        void Add<Tsource, TDestination>();

        object CreateInstance(Type type);
    }
}
