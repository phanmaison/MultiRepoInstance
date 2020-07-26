using Repositories.Models;
using System.Collections.Generic;

namespace Services.Models
{
    public class SearchRequest
    {
        public List<string> Ids { get; set; }

        public string Location { get; set; }

        public int? Period { get; set; }

        public SearchFilter ToSearchFilter()
        {
            return new SearchFilter
            {
                Location = this.Location,
                Period = this.Period
            };
        }
    }
}
