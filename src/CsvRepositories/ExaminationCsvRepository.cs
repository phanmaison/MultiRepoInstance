using Repositories;
using Repositories.Models;
using System;

namespace CsvRepositories
{
    public interface IExaminationCsvRepository : IExaminationRepository
    {
        // add specific implementation for Csv if any
    }

    public class ExaminationCsvRepository : InstanceLogger, IExaminationCsvRepository
    {
        private string _examinationType;

        // indicate this instance used for a specific examinationType
        public void SetExamination(string examinationType)
        {
            _examinationType = examinationType;
        }

        public ExaminationResult FilterExamination(SearchFilter filter)
        {
            if (string.IsNullOrEmpty(_examinationType))
                throw new InvalidOperationException("The repository is not initialized");

            // get examination from {_examinationType}.csv
            return new ExaminationResult
            {
                Content = $"{InstanceName}: FilterExamination: type = {_examinationType}, {filter.GetLog()}"
            };
        }

    }
}
