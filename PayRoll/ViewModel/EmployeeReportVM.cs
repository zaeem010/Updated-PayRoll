using PayRoll.Models;
using PayRoll.ViewModelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayRoll.ViewModel
{
    public class EmployeeReportVM
    {
        public List<Employee> EmployeeList { get; set; }
        public List<PayRollCalender> PayRollCalenderList { get; set; }
        public List<EmployeeAttendanceReport> EmployeeAttendanceReportList { get; set; }
        public ERVMQ ERVMQ { get; set; }
        public int PresentDays { get; set; }
        public int AbsentDays { get; set; }
        public int RestDays { get; set; }
        public int TotalDays { get; set; }
        public int Late { get; set; }
        public string OffDays { get; set; }
        public string ShiftName { get; set; }
        public DateTime MonthName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}