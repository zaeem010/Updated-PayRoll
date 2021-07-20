using PayRoll.Models;
using PayRoll.ViewModelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayRoll.ViewModel
{
    public class RsAssignReportVM
    {
        public List<RsAssignShiftsVMQ> RsAssignShiftsVMQList { get; set; }
        public List<RsAssignListVMQ> RsAssignChildList { get; set; }
    }
}