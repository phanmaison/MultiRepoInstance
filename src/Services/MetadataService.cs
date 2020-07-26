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
        private readonly IExaminationRepository _examinationRepository;

        public MetadataService(IMetadataRepository metadataRepository, IExaminationRepository examinationRepository)
        {
            _metadataRepository = metadataRepository;
            _examinationRepository = examinationRepository;
        }

        public List<ExaminationTypeModel> GetData()
        {
            return _metadataRepository.GetExaminations();
        }

    }
}
