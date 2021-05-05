using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avia8r.Models
{
    public class FlightLegEdit
    {
        public int TripId { get; set; }
        public string OriginAirport { get; set; }
        public string DestinationAirport { get; set; }
        public DateTime DepartureDate { get; set; }
        public string AcTail { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
