using System;
using System.Text;
using System.Reflection;

public class Tracker
{
    public static void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);
        var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

        foreach (var method in methods)
        {
            var attributes = method.GetCustomAttributes(false);

            foreach (var attribute in attributes)
            {
                if (attribute.GetType() == typeof(AuthorAttribute))
                {
                    Console.WriteLine($"{method.Name} is written by {((AuthorAttribute)attribute).Name}");
                }
            }                      
        }
    }
}
