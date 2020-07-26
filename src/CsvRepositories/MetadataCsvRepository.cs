using Repositories.Data;
using Repositories.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class MetadataCsvRepository : InstanceLogger, IMetadataRepository
    {
        public List<ExaminationTypeModel> GetExaminations()
        {
            // get from csv
            return ExaminationTypeData.Dictionary.Values.ToList();
        }
    }
}
