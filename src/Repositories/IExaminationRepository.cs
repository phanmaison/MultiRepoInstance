using Repositories.Models;

namespace Repositories
{
    public interface IExaminationRepository
    {
        /// <summary>
        /// Filters the examination.
        /// </summary>
        ExaminationResult FilterExamination(SearchFilter filter);
    }
}
