using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayRoll.ViewModelQuery
{
    public class RestDayForsalary
    {
        public string EmpCode { get; set; }
        public string Name { get; set; }
        public string RoasterName { get; set; }
    }
    public class EmpForRoaster
    {
        public string EmpCode { get; set; }
        public string Name { get; set; }
        public string RoasterName { get; set; }
    }
    public class MonthlySalaryReportVMQ
    {
        public string EmpCode { get; set; }
        public string Name { get; set; }
        public int USERID { get; set; }
        public int Presentdays { get; set; }
        public int Absentdays { get; set; }
        public int Monthdays { get; set; }
        public int Workingdays { get; set; }
        public string Total { get; set; }
    }
    public class MonthlySalaryAddRestReportVMQ
    {
        public string EmpCode { get; set; }
        public string Name { get; set; }
        public int USERID { get; set; }
        public int Presentdays { get; set; }
        public int Absentdays { get; set; }
        public int Monthdays { get; set; }
        public int Workingdays { get; set; }
        public int Restdays { get; set; }
        public decimal salary { get; set; }
    }
    public class MonthlySalaryVMQ 
    {
        public string EmpCode { get; set; }
        public string Name { get; set; }
        public string Total { get; set; }
    }
    public class EmployeeDailyReportVMQ
    {
        public int id { get; set; }
        public string EmpCode { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string DateName { get; set; }
        public DateTime DateTimeIn { get; set; }
        public DateTime DateTimeout { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public string Final { get; set; }
        public int OverTime { get; set; }
        public string ShiftName { get; set; }
        public DateTime ShiftStartTime { get; set; }
        public DateTime ShiftEndTime { get; set; }
    }
    public class RsAssignCreateVMQ
    {
        public string LeaveDay { get; set; }
        public string ShiftName { get; set; }
        public string EmpCode { get; set; }
        public string Name { get; set; }
    }
    public class RsAssignListVMQ
    {
        public int RsAssignid { get; set; }
        public string Name { get; set; }
        public string EmpCode { get; set; }
        public string LeaveDay { get; set; }
        public string Designation { get; set; }
    }
    public class RsAssignShiftsVMQ
    {
        public int RsAssignid { get; set; }
        public int Shiftid { get; set; }
        public string Name { get; set; }
        public DateTime StTime { get; set; }
        public DateTime EnTime { get; set; }
    }
    public class RsAssignVMQ
    {
        public int Shiftid { get; set; }
        public int RsAssignid { get; set; }
        public string Name { get; set; }
        public DateTime StTime { get; set; }
        public DateTime EnTime { get; set; }
        public DateTime DateTime { get; set; }
    }
    public class ERVMQ
    {
        public string EmpCode  { get; set; }
        public string Name  { get; set; }
        public string Cnic  { get; set; }
        public string JoiningDate  { get; set; }
        public string BranchName  { get; set; }
        public string DepartmentName  { get; set; }
        public string DesignationName  { get; set; }
        //public string ShiftName  { get; set; }
        public string offDay  { get; set; }
    }
    public class EmployeeAttendaceApprovalVMQ
    {
        public int id { get; set; }
        public string EmpCode { get; set; }
        public int Managerid { get; set; }
        public string Status { get; set; }
        public DateTime CheckInDatetime { get; set; }
        public DateTime CheckOutDatetime { get; set; }
        public string Remarks { get; set; }
        public string EmployeeName { get; set; }
        public string ManagerName { get; set; }
    }
    public class LeaveApprovalVMQ
    {
        public int id { get; set; }
        public int Managerid { get; set; }
        public int EmployeeAcc { get; set; }
        public string StDate { get; set; }
        public string EnDate { get; set; }
        public string Status { get; set; }
        public string EmployeeName { get; set; }
        public string ManagerName { get; set; }
        public string Narration { get; set; }
    }
    public class OTApprovalVMQ
    {
        public int id { get; set; }
        public int Managerid { get; set; }
        public int EmployeeAcc { get; set; }
        public string StDate { get; set; }
        public string EnDate { get; set; }
        public string Status { get; set; }
        public string EmployeeName { get; set; }
        public string ManagerName { get; set; }
        public string Narration { get; set; }
    }
    public class AssignsRoasterVMQ
    {
        public int Roasterid { get; set; }
        public string ShiftName { get; set; }
        public string Day { get; set; }
    }
    public class AssignRoasterVMQ
    {
        public int Roasterid { get; set; }
        public string RoasterName { get; set; }
    }
    public class EmployeeVMQ
    {
        public int id { get; set; }
        public string Image { get; set; }
        public string EmpCode { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public string Cnic { get; set; }
       // public string Shift { get; set; }
        public string Depart { get; set; }
        public string Designation { get; set; }
        public string Roaster { get; set; }
        public string Phone { get; set; }
        public string EmployeeStatus { get; set; }
    }
}