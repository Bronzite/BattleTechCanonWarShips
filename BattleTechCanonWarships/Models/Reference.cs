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

    public class ReferenceSummary
    {
        public ReferenceSummary(Reference r)
        {
            Id = r.Id;
            if(r.URL != null) 
            {
                Description = r.URL;
                if(r.URLCapture.HasValue)
                {
                    Description = string.Format("{0} (retrieved {1})", r.URL, r.URLCapture.Value.ToShortDateString());
                }
            }
            else
            {
                Description = string.Format("{0} p. {1}", r.Source.Title, r.Page);
            }
        }

        public Guid Id { get; set; }
        public string Description {get;set;}
    }
}
