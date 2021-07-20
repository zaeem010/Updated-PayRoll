using PayRoll.Models;
using PayRoll.ViewModelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayRoll.ViewModel
{
    public class RoasterUpdateVM
    {
        public RoasterUpdate RoasterUpdate { get; set; }
        public RestdayUpdate RestdayUpdate { get; set; }
        public List<EmpForRoaster> EmpForRoasterList { get;set; }
        public List<Roaster> RoasterList { get; set; }
    }
    
}