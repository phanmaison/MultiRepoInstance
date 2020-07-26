using Repositories.Models;
using System.Data;

namespace Repositories
{
    public class ExaminationSqlRepository : InstanceLogger, IExaminationRepository
    {
        private string _examinationType;
        private string _connectionString;

        public ExaminationSqlRepository(string examinationType, string connectionString)
        {
            _examinationType = examinationType;
            _connectionString = connectionString;
        }

        public ExaminationResult FilterExamination(SearchFilter filter)
        {
            // get examination from {_examinationType} table
            return new ExaminationResult
            {
                Content = $"{InstanceName}: FilterExamination: type = {_examinationType}, {filter.GetLog()}. Using ConnectionString = {_connectionString}"
            };
        }

    }
}
