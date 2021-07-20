using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayRoll.Models
{
    public class EmployeeAttendanceApproval
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string EmpCode { get; set; }
        public int Managerid { get; set; }
        public int Comid { get; set; }
        public string Status { get; set; }
        public DateTime CheckInDatetime { get; set; }
        public DateTime CheckOutDatetime { get; set; }
        public string Remarks { get; set; }
    }
}