using Repositories.Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface IMetadataRepository
    {
        List<ExaminationTypeModel> GetExaminations();
    }
}
