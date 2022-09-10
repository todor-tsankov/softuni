using System;
using System.Linq;
using System.Collections.Generic;

namespace MySUS.MvcFramework
{
    public class ServiceCollection : IServiceCollection
    {
        private IDictionary<Type, Type> dependencyContainer;

        public ServiceCollection()
        {
            this.dependencyContainer = new Dictionary<Type, Type>();
        }

        public void Add<Tsource, TDestination>()
        {
            var sourceType = typeof(Tsource);
            var destinationType = typeof(TDestination);

            this.dependencyContainer[sourceType] = destinationType;
        }

        public object CreateInstance(Type type)
        {
            if (this.dependencyContainer.ContainsKey(type))
            {
                type = this.dependencyContainer[type];
            }

            var constructor = type
                .GetConstructors()
                .OrderBy(x => x.GetParameters().Count())
                .First();

            var parameters = constructor.GetParameters();
            var parameterInstances = new List<object>();

            foreach (var parameter in parameters)
            {
                var parameterInstance = this.CreateInstance(parameter.ParameterType);

                parameterInstances.Add(parameterInstance);
            }

            return constructor.Invoke(parameterInstances.ToArray());
        }
    }
}
