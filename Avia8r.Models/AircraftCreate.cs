using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Avia8r.Models
{
    public class AircraftCreate
    {
        [Required]
        public string AcTail { get; set; }
        [Required]
        public string AcModel { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Airline { get; set; }
    }
}