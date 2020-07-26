using Repositories;
using Repositories.Models;

namespace CsvRepositories
{
    public class ExaminationCsvRepository : InstanceLogger, IExaminationRepository
    {
        private string _examinationType;

        public ExaminationCsvRepository(string examinationType)
        {
            _examinationType = examinationType;
        }

        public ExaminationResult FilterExamination(SearchFilter filter)
        {
            // get examination from {_examinationType}.csv
            return new ExaminationResult
            {
                Content = $"{InstanceName}: FilterExamination: type = {_examinationType}, {filter.GetLog()}"
            };
        }

    }
}
