using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IronDome.Models
{
    public class Threat
    {


        public Threat()
        {
            status = ThreatStatus.InActive;
        }

        [Key]
        public int id { get; set; }

        [NotMapped]
        public int responseTime { get { return Org.distance / type.speed; } }

        public TerrorOrg Org { get; set; }

        public ThreatAmmunition type { get; set; }

        public ThreatStatus status { get; set; }

        public DateTime? fired_at { get; set; }
    }


    public enum ThreatStatus
    {
        InActive,
        Active,
        Failed,
        Succeeded
    }
}
