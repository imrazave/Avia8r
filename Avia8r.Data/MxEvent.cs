using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avia8r.Data
{
    public enum TypeOfMx
    {
        light = 1,
        medium,
        heavy
    }
    public class MxEvent
    {
        [Key]
        public int MxId { get; set; }
        [ForeignKey(nameof(Aircraft))]
        public string AcTail { get; set; }
        public virtual Aircraft Aircraft { get; set; }
        [Required]
        public TypeOfMx TypeOfMx { get; set; }
        [Required]
        public String MxDescription { get; set; }
        [Required]
        public int ManHours { get; set; }
        [Required]
        public int HoursOutOfService { get; set; }
        public double Cost { get; set; }
    }
}
