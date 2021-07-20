using PayRoll.ViewModelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayRoll.ViewModel
{
    public class DailyReportVM
    {
        public List<EmployeeDailyReportVMQ> EmployeeDailyReportVMQList { get; set; }
        public string DateName { get; set; }
    }
}