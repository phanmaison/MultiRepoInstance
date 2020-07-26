using Repositories.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Repositories
{
    public interface IExaminationSqlRepository : IExaminationRepository
    {
        /// <summary>
        /// Set the data source if any
        /// </summary>
        void SetConnection(string dataSource);

    }

    public class ExaminationSqlRepository : InstanceLogger, IExaminationSqlRepository
    {
        private string _examinationType;
        private string _connectionString;
        private IDbConnection _dbConnection;

        // indicate this instance used for a specific examinationType
        public void SetExamination(string examinationType)
        {
            _examinationType = examinationType;
        }

        // point to specific database for each examination type
        public void SetConnection(string connectionString)
        {
            _connectionString = connectionString;
            _dbConnection = new SqlConnection(connectionString);
        }

        public ExaminationResult FilterExamination(SearchFilter filter)
        {
            if (string.IsNullOrEmpty(_examinationType))
                throw new InvalidOperationException("The repository is not initialized");

            // get examination from {_examinationType} table
            return new ExaminationResult
            {
                Content = $"{InstanceName}: FilterExamination: type = {_examinationType}, {filter.GetLog()}. Using ConnectionString = {_connectionString}"
            };
        }

    }
}
