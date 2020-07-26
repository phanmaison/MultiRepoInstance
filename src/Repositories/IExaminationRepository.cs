using Repositories.Models;

namespace Repositories
{
    public interface IExaminationRepository
    {
        /// <summary>
        /// Indicate this instance used for a specific examinationType
        /// </summary>
        void SetExamination(string examinationType);

        /// <summary>
        /// Filters the examination.
        /// </summary>
        ExaminationResult FilterExamination(SearchFilter filter);
    }
}
