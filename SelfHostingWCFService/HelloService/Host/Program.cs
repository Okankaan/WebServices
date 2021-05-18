using System;
using System.ServiceModel;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(HelloService.HelloService))) //Endpoint and another configurations are coming from App.config
            {
                host.Open();
                Console.WriteLine("Host Started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
