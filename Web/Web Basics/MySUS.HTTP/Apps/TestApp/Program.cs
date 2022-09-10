using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using MySUS.HTTP;
using MySUS.MvcFramework;

namespace TestApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateHostAsync<StartUp>();
        }
    }
}
