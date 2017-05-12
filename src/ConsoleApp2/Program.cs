using Avalara.AvaTax.RestClient;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine($"Hello {AvaTaxClient.API_VERSION} and {AvaTaxClient.SDK_TYPE}");
        }
    }
}