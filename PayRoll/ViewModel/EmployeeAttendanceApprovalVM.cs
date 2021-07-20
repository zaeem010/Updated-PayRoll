using PayRoll.ViewModelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayRoll.ViewModel
{
    public class EmployeeAttendanceApprovalVM
    {
        public List<EmployeeAttendaceApprovalVMQ> Pending { get; set; }
        public List<EmployeeAttendaceApprovalVMQ> Approved { get; set; }
        public List<EmployeeAttendaceApprovalVMQ> Rejected { get; set; }
    }
}