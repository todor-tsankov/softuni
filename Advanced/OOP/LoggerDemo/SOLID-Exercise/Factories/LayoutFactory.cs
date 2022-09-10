using System;
using System.Linq;
using System.Reflection;

using SOLID_Exercise.Models.Contracts;

namespace SOLID_Exercise.Factories
{
    public class LayoutFactory
    {
        public ILayout ProduceLayout(string typeStr)
        {
            var type = Assembly.GetCallingAssembly()
                               .GetTypes()
                               .FirstOrDefault(t => t.Name == typeStr);

            if (type == null)
            {
                throw new ArgumentException("Invalid Layout type!");
            }

            var layout = (ILayout)Activator.CreateInstance(type);

            return layout;
        }
    }
}
