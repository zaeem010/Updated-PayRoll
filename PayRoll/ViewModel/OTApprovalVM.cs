using PayRoll.ViewModelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayRoll.ViewModel
{
    public class OTApprovalVM
    {
        public List<OTApprovalVMQ> Pending { get; set; }
        public List<OTApprovalVMQ> Approved { get; set; }
        public List<OTApprovalVMQ> Rejected { get; set; }
    }
    public class LeaveApprovalVM
    {
        public List<LeaveApprovalVMQ> Pending { get; set; }
        public List<LeaveApprovalVMQ> Approved { get; set; }
        public List<LeaveApprovalVMQ> Rejected { get; set; }
    }
}