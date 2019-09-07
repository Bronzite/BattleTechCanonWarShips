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
        public string Role { get; set; }
        public int Crew { get; set;}
        public int? NumberInClass { get; set; }
        public string Image { get; set; }
        public ICollection<Vessel> Vessels { get; set; }
    }


    public class ShipClassSummary
    {
        public ShipClassSummary(ShipClass shipClass)
        {
            Id = shipClass.Id;
            Name = shipClass.Name;
            Tonnage = shipClass.Tonnage;
            Role = shipClass.Role;
            Image = shipClass.Image;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Tonnage { get; set; }
        public string Role { get; set; }
        public string Image { get; set; }
        
    }

    public class ShipClassDetail
    {
        public ShipClassDetail(ShipClass shipClass)
        {
            Id = shipClass.Id;
            Name = shipClass.Name;
            Tonnage = shipClass.Tonnage;
            IntroductionYear = shipClass.IntroductionYear;
            Length = shipClass.Length;
            Role = shipClass.Role;
            Crew = shipClass.Crew;
            NumberInClass = shipClass.NumberInClass;
            Image = shipClass.Image;
            Vessels = new List<VesselSummary>();
            foreach(Vessel v in shipClass.Vessels)
            {
                Vessels.Add(new VesselSummary(v));
            }
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Tonnage { get; set; }
        public int IntroductionYear { get; set; }
        public int Length { get; set; }
        public string Role { get; set; }
        public int Crew { get; set; }
        public int? NumberInClass { get; set; }
        public string Image { get; set; }
        public ICollection<VesselSummary> Vessels { get; set; }
    }
}
