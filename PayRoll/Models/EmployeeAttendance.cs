using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayRoll.Models
{
    public class EmployeeAttendance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int Comid { get; set; }
        public string EmpCode { get; set; }
        public string Status { get; set; }
        public DateTime Datetime { get; set; }
        public string Remarks { get; set; }
    }
}