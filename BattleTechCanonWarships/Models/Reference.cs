using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleTechCanonWarships.Models
{
    public class Reference
    {
        public Guid Id { get; set; }
        public string URL { get; set; }
        public DateTime? URLCapture { get; set; }
        public Guid? SourceId { get; set; }
        public Source Source { get; set; }
        public int? Page { get; set; }
        public string Quote { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ValidatedBy { get; set; }
        public DateTime? ValidatedOn { get; set; }
    }
}
