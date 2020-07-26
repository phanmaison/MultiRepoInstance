using Repositories;
using Repositories.Models;
using Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public interface IExaminationService
    {
        SearchResponse SearchExamination(SearchRequest request);
    }

    public class ExaminationService : InstanceLogger, IExaminationService
    {
        List<IExaminationRepository> _examinationRepositories;

        public ExaminationService(List<IExaminationRepository> examinationRepositories)
        {
            _examinationRepositories = examinationRepositories;
        }

        public SearchResponse SearchExamination(SearchRequest request)
        {
            var results = new List<ExaminationResult>();

            StringBuilder sb = new StringBuilder();

            foreach (var repo in _examinationRepositories)
            {
                var filter = request.ToSearchFilter();
                var content = repo.FilterExamination(filter);
                results.Add(content);
            }

            // build result;
            return new SearchResponse
            {
                Content = "ExaminationService: Result:\n" + string.Join("\n", results.Select(x => x.Content))
            };
        }
    }
}
