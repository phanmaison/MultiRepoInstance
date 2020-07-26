using CsvRepositories;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repositories.Data;
using Services;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Funtions.Configs
{
    public static class DIConfig
    {
        public static IServiceProvider DefaultServiceProvider => CreateDefaultServiceCollection().BuildServiceProvider();

        // get from configuration
        private const string DefaultConnectionString = "Server=local;Database=db;";

        /// <summary>
        /// Default ServiceCollection for almost cases
        /// </summary>
        public static IServiceCollection CreateDefaultServiceCollection()
        {
            IServiceCollection collection = new ServiceCollection();

            // service
            collection.AddScoped<IExaminationService, ExaminationService>();
            collection.AddScoped<IMetadataService, MetadataService>();

            // repository
            collection.AddScoped<IMetadataRepository, MetadataSqlRepository>();
            // no need to register IExaminationRepository

            // db connection
            collection.AddScoped<IDbConnection>((serviceProvider) => { return new SqlConnection(DefaultConnectionString); });

            return collection;
        }

        /// <summary>
        /// Create service collection for Search function
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public static IServiceCollection CreateSearchServiceCollection(SearchRequest request)
        {
            /**
             * in case of Search function, we need multiple instances of IExaminationRepository
             * each instance can point to either SqlServer or Csv (or another datasource)
             * hence we creae another ServiceCollection for such specific case
             */

            var collection = CreateDefaultServiceCollection();

            // override default collection
            // create multiple instances of IUserRepository
            collection.AddScoped<List<IExaminationRepository>>((serviceProvider) =>
            {
                List<IExaminationRepository> repositories = new List<IExaminationRepository>();

                foreach (var examinationType in request.Ids)
                {
                    IExaminationRepository repo;

                    // create new instance based on configuration
                    if (!ExaminationTypeConfig.Providers.ContainsKey(examinationType) ||
                        ExaminationTypeConfig.Providers[examinationType] != ExaminationDataSource.Csv)
                    {
                        repo = new ExaminationSqlRepository(examinationType, ExaminationTypeData.Dictionary[examinationType].ConnectionString);
                    }
                    else
                    {
                        repo = new ExaminationCsvRepository(examinationType);
                    }

                    repositories.Add(repo);
                }

                return repositories;
            });

            return collection;
        }
    }
}
