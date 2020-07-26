using Funtions.Configs;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Models;
using System;
using System.Collections.Generic;

namespace Funtions
{
    public class SearchFunction
    {
        public void Run()
        {
            Console.WriteLine("******************************************");
            Console.WriteLine("* SearchFunction");
            Console.WriteLine("******************************************");

            var request = new SearchRequest
            {
                Ids = new List<string> {
                    "Type 1", // use Csv
                    "Type 2", // use Sql, connection2
                    "Type 3"  // use Sql, connection3
                },
                Location = "New York",
                Period = 2019
            };

            var serviceProvider = DIConfig.CreateSearchServiceCollection(request).BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<IExaminationService>();

                SearchResponse response = service.SearchExamination(request);

                Console.WriteLine(response.Content);

            }
        }
    }
}
