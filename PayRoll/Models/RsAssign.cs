using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayRoll.Models
{
    public class RsAssign
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int RsAssignid { get; set; }
        public int Comid { get; set; }
        public int Shiftid { get; set; }
        public DateTime DateTime { get; set; }
    }
    public class RsAssignChild
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int RsAssignid { get; set; }
        public int Comid { get; set; }
        public string EmpCode { get; set; } 
        public string LeaveDay { get; set; } 
    }
}