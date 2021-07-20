using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayRoll.ViewModel
{
    public class EmployeeAttendanceVM
    {
        public EmployeeAttendance EmployeeAttendance { get; set; }
        public EmployeeAttendanceApproval EmployeeAttendanceApproval { get; set; }
        public List<Employee> EmployeeList { get; set; }
    }
}