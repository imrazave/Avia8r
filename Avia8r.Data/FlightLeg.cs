using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avia8r.Data
{
    public class FlightLeg
    {
        [Key]
        public int TripId { get; set; }
        [Required]
        public string OriginAirport { get; set; }
        [Required]
        public string DestinationAirport { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        
        [ForeignKey(nameof(Aircraft))]
        public string AcTail { get; set; }
        public virtual Aircraft Aircraft { get; set; }

        [Required]
        public DateTime ArrivalDate { get; set; }
    }
}
