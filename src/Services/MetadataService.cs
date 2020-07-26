using Repositories;
using Repositories.Models;
using System.Collections.Generic;

namespace Services
{
    public interface IMetadataService
    {
        List<ExaminationTypeModel> GetData();
    }

    public class MetadataService : InstanceLogger, IMetadataService
    {
        private readonly IMetadataRepository _metadataRepository;

        public MetadataService(IMetadataRepository metadataRepository)
        {
            _metadataRepository = metadataRepository;
        }

        public List<ExaminationTypeModel> GetData()
        {
            return _metadataRepository.GetExaminations();
        }

    }
}
