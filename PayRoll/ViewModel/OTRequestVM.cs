using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayRoll.ViewModel
{
    public class OTRequestVM
    {
        public OTRequest OTRequest { get; set; }
        public List<Employee> EmployeeList { get; set; }

    }
    public class LeaveRequestVM
    {
        public LeaveRequest LeaveRequest { get; set; }
        public List<Employee> EmployeeList { get; set; }

    }
}