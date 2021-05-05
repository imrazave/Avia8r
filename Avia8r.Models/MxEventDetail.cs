using Avia8r.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avia8r.Models
{
    public class MxEventDetail
    {
        public int MxId { get; set; }
        public string AcTail { get; set; }
        public TypeOfMx TypeOfMx { get; set; }
        public string MxDescription { get; set; }
        public int ManHours { get; set; }
        public int HoursOutOfService { get; set; }
        public double Cost { get; set; }
    }
}
