using Funtions.Configs;
using Microsoft.Extensions.DependencyInjection;
using Services;
using System;
using System.Linq;

namespace Funtions
{
    public class MetadataFunction
    {
        public void Run()
        {
            Console.WriteLine("******************************************");
            Console.WriteLine("* MetadataFunction");
            Console.WriteLine("******************************************");

            var serviceProvider = DIConfig.DefaultServiceProvider;

            using (var scope = serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<IMetadataService>();
                var result = service.GetData();

                Console.WriteLine("* Result:");
                Console.WriteLine(string.Join("\n", result.Select(x => x.ExaminationType)));

                // try to call another time
                // it shouldn't create another instance
                Console.WriteLine("* Is new instance created?");
                var service2 = scope.ServiceProvider.GetRequiredService<IMetadataService>();
                result = service.GetData();

            }
        }
    }
}
