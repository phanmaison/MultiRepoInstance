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
            collection.AddScoped<IExaminationRepository, ExaminationSqlRepository>();
            collection.AddScoped<IMetadataRepository, MetadataSqlRepository>();

            // db connection
            collection.AddScoped<IDbConnection>((serviceProvider) => { return new SqlConnection("Server=local;Database=db;"); });

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
            collection.AddTransient<IExaminationRepository, ExaminationSqlRepository>();
            collection.AddTransient<IExaminationSqlRepository, ExaminationSqlRepository>();
            collection.AddTransient<IExaminationCsvRepository, ExaminationCsvRepository>();

            // create multiple instances of IUserRepository
            collection.AddScoped<List<IExaminationRepository>>((serviceProvider) =>
            {
                List<IExaminationRepository> repositories = new List<IExaminationRepository>();

                foreach (var examinationType in request.Ids)
                {
                    // create new instance based on configuration
                    if (!ExaminationTypeConfig.Providers.ContainsKey(examinationType) ||
                        ExaminationTypeConfig.Providers[examinationType] != ExaminationDataSource.Csv)
                    {
                        var repo = serviceProvider.GetService<IExaminationSqlRepository>();
                        repo.SetExamination(examinationType);
                        repo.SetConnection(ExaminationTypeData.Dictionary[examinationType].ConnectionString);
                        repositories.Add(repo);
                    }
                    else
                    {
                        var repo = serviceProvider.GetService<IExaminationCsvRepository>();
                        repo.SetExamination(examinationType);
                        repositories.Add(repo);
                    }
                }

                return repositories;
            });

            return collection;
        }
    }
}
