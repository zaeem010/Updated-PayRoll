using PayRoll.Models;
using PayRoll.ViewModelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayRoll.ViewModel
{
    public class AssignRoasterVM
    {
        public AssignRoaster AssignRoaster { get; set; }
        public List<Roaster> RoasterList { get; set; }
        public List<Shiftes> ShiftList { get; set; }
        public List<AssignRoasterVMQ> AssignRoasterVMQList { get; set; }
        public List<AssignsRoasterVMQ> AssignsRoasterVMQList { get; set; }
        public int Monday { get; set; }
        public int Tuesday { get; set; }
        public int Wednesday { get; set; }
        public int Thursday { get; set; }
        public int Friday { get; set; }
        public int Saturday { get; set; }
        public int Sunday { get; set; }
    }
}