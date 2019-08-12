using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleTechCanonWarships.Models
{
    public class SourceReview
    {
        public Guid Id { get; set; }
        public Guid SourceId { get; set; }
        public Source Source { get; set; }
        public DateTime ReviewDate { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public string Reviewer { get; set; }
    }
}
