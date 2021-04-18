using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avia8r.Data
{
    public class FlightLeg
    {
        public int TripId { get; set; }
        public string OriginAirport { get; set; }
        public string DestinationAirport { get; set; }
        public DateTime DepartureDate { get; set; }
        public Guid AcTail { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
