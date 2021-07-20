using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayRoll.ViewModel
{
    public class EmployeeVM
    {
        public Employee Employee { get; set; }
        public SalaryPackage SalaryPackage { get; set; }
        public SalaryPackage SalaryDup { get; set; }
        public List<Branch> BranchList { get; set; }
        public List<Departmentes> DepartList { get; set; }
        public List<Designation> DesignationList { get; set; }
        public List<Employee> LineManagerList { get; set; }
        public List<Employee> OTApprovalList { get; set; }
        public List<Employee> LeaveApprovalList { get; set; }
        public List<Roaster> RoasterList { get; set; }
        public List<SalaryPackage> SalaryList { get; set; }
        public List<Shiftes> ShiftList { get; set; }
        public List<Bank> BankList { get; set; }
        public int Code { get; set; }
    }
}