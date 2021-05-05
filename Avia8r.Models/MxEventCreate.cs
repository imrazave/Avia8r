using Avia8r.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Avia8r.Models
{
    public class MxEventCreate
    {
        [Required]
        public int MxId { get; set; }
        [Required]
        public string AcTail { get; set; }
        [Required]
        public TypeOfMx TypeOfMx { get; set; }
        [Required]
        public string MxDescription { get; set; }
        [Required]
        public int ManHours { get; set; }
        [Required]
        public int HoursOutOfService { get; set; }
        [Required]
        public double Cost { get; set; }
    }
}