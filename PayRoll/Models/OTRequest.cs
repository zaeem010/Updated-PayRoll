using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayRoll.Models
{
    public class OTRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int EmployeeAcc { get; set; }
        public int Managerid { get; set; }
        public int Comid { get; set; }
        public string StDate { get; set; }
        public string EnDate { get; set; }
        public string Status { get; set; }
        public string Narration { get; set; }
    }
    public class LeaveRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int EmployeeAcc { get; set; }
        public int Managerid { get; set; }
        public int Comid { get; set; }
        public string StDate { get; set; }
        public string EnDate { get; set; }
        public string Status { get; set; }
        public string Narration { get; set; }
    }
}