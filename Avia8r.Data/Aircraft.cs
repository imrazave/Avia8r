using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avia8r.Data
{
    public class Aircraft
    {
        [Key]
        public string AcTail { get; set; }
        [Required]
        public string AcModel { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Airline { get; set; }
    }
}
