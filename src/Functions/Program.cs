using System;

namespace Funtions
{
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        static void Main(string[] args)
        {
            // search function
            new SearchFunction().Run();

            Console.WriteLine();

            // metadata function
            new MetadataFunction().Run();

            Console.ReadLine();
        }
    }
}
