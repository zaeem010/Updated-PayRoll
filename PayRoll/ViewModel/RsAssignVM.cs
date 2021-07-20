using PayRoll.Models;
using PayRoll.ViewModelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayRoll.ViewModel
{
    public class RsAssignVM
    {
        public RsAssign RsAssign { get; set; }
        public List<Employee> EmployeeList { get; set; }
        public List<Roaster> RoasterList { get; set; }
        public List<Shiftes> ShiftList { get; set; }
        public List<Days> DayList { get; set; }
        public List<RsAssignChild> RsAssignChildList { get; set; }
        public List<RsAssignCreateVMQ> RsAssignCreateVMQ { get; set; }
    }
}