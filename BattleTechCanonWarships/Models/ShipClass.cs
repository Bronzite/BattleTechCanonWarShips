using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleTechCanonWarships.Models
{
    public class ShipClass
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Tonnage { get; set; }
        public int IntroductionYear { get; set; }
        public int Length { get; set; }
        public int Role { get; set; }
        public int Crew { get; set;}
        public int NumberInClass { get; set; }
        public string Image { get; set; }
    }
}
