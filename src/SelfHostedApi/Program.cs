using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostedApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var listeningOn = "http://localhost:1212/";
            var appHost = new SelfAppHost(new SelfAppHostConfig());
            appHost.Init();
            appHost.Start(listeningOn);

            Console.WriteLine("SelfAppHost Created at {0}, listening on {1}", DateTime.Now, listeningOn);


            Console.ReadKey();
        }
    }
}
