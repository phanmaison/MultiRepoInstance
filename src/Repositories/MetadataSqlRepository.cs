using Repositories.Data;
using Repositories.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Repositories
{
    public class MetadataSqlRepository : InstanceLogger, IMetadataRepository
    {
        private readonly IDbConnection _dbConnection;

        public MetadataSqlRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<ExaminationTypeModel> GetExaminations()
        {
            return ExaminationTypeData.Dictionary.Values.ToList();
        }
    }
}
