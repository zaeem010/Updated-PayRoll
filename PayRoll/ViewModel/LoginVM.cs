using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayRoll.ViewModel
{
    public class LoginVM
    {
        public UserLogin UserLogin { get; set; }
        public List<Branch> BranchList { get; set; }
    }
}