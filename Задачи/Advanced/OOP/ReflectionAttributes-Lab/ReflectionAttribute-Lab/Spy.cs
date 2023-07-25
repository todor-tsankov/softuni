using System;
using System.Text;
using System.Linq;
using System.Reflection;

public class Spy
{
    public string CollectGettersAndSetters(string investigatedClass)
    {
        var classType = Type.GetType(investigatedClass);
        var methods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        var sb = new StringBuilder();

        foreach (var method in methods)
        {
            var name = method.Name;

            if (name.StartsWith("get_"))
            {
                sb.AppendLine($"{name} will return {method.ReturnType}");
            }
        }

        foreach (var method in methods)
        {
            var name = method.Name;

            if (name.StartsWith("set_"))
            {
                sb.AppendLine($"{name} will set field of {method.GetParameters().First().ParameterType.FullName}");
            }
        }

        return sb.ToString()
                 .TrimEnd();
    }
}
