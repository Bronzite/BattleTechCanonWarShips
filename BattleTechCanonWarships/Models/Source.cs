using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleTechCanonWarships.Models
{
    public class Source
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public ICollection<SourceReview> SourceReviews { get; set;}

        public class SourceSummary
        {
            public SourceSummary(Source s)
            {
                Id = s.Id;
                Title = s.Title;
            }
            public Guid Id { get; set; }
            public string Title { get; set; }
        }
    }
}
