using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;
using Serilog;

namespace OwinSelfHosting
{
    public class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9780/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpClient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/values").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine("Service started");
                Log.Information($"Service started at url {baseAddress}");
                Console.ReadLine();
            }
        }
    }
}
