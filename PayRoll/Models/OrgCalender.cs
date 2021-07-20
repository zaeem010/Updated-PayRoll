using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayRoll.Models
{
    public class OrgCalender
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Name { get; set; }
        public string StDate { get; set; }
        public string EnDate { get; set; }
        public string OT { get; set; }
        public string OTMBy { get; set; }
        public int Comid { get; set; }
    }
}