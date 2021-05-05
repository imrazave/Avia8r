using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Avia8r.Models
{
    public class FlightLegCreate
    {
        [Required]
        public int TripId { get; set; }
        [Required]
        public string OriginAirport { get; set; }
        [Required]
        public string DestinationAirport { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public string AcTail { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
    }
}