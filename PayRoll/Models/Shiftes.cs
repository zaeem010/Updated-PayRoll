using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayRoll.Models
{
    public class Shiftes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime StTime { get; set; }
        public DateTime EnTime { get; set; }
        public string EarlyStTimeinMin { get; set; }
        public string LateStTimeinMin { get; set; }
        public string EarlyEnTimeinMin { get; set; }
        public string LateEnTimeinMin { get; set; }
        public int ShiftHours { get; set; }
        public int Comid { get; set; }
    }
}