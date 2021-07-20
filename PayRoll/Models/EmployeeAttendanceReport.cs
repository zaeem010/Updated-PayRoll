using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayRoll.Models
{
    public class EmployeeAttendanceReport
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string EmpCode { get; set; }
        public int Calenderid { get; set; }
        public string Date { get; set; }
        public string DateName { get; set; }
        public DateTime DateTimeIn { get; set; }
        public DateTime DateTimeout { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public string Final { get; set; }
        public int OverTime { get; set; }
        public string ShiftName { get; set; }
        public DateTime ShiftStartTime { get; set; }
        public DateTime ShiftEndTime { get; set; }
    }
}