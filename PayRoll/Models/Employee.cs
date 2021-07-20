using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayRoll.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Image { get; set; }
        public string EmpCode { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string City { get; set; }
        public string Cnic { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string EmerPhone { get; set; }
        public int Branchid { get; set; }
        public int Departid { get; set; }
        public string Type { get; set; }
        public int Designationid { get; set; }
        public int Managerid { get; set; }
        public int Roasterid { get; set; }
        public bool overTime { get; set; }
        //public int OTApproval { get; set; }
        //public int LeaveApproval { get; set; }
        public string JoiningDate { get; set; }
        public string idDetail { get; set; }
        public string LeaveCal { get; set; }
        public int salaryid { get; set; }
        public string BankInfo { get; set; }
        public string PaymentTransfertype { get; set; }
        public string offDay { get; set; }
        public string NumberOfleaves { get; set; }
        public string AttendanceSandwitch { get; set; }
        public int comid { get; set; }
        public int EmployeeAcc { get; set; }
        //public int Shiftid { get; set; }
        public int GeneCode { get; set; }
        public string BankAcc { get; set; }
        public string EmployeeStatus { get; set; }
        public string ResignDate { get; set; }
        public string BlockNote { get; set; }
        public string EmpQualification { get; set; }
        public decimal PerHourSalary { get; set; }
    }
}