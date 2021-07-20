using PayRoll.Models;
using PayRoll.ViewModel;
using PayRoll.ViewModelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class EmployeeAttendanceController : Controller
    {
        private ApplicationDbContext _context;
        public EmployeeAttendanceController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: EmployeeAttendance
        public ActionResult Index()
        {
            var pending = _context.Database.SqlQuery<EmployeeAttendaceApprovalVMQ>("SELECT EmployeeAttendanceApprovals.id, EmployeeAttendanceApprovals.EmpCode, EmployeeAttendanceApprovals.Managerid, EmployeeAttendanceApprovals.Status, EmployeeAttendanceApprovals.CheckInDatetime, EmployeeAttendanceApprovals.CheckOutDatetime, EmployeeAttendanceApprovals.Remarks, Employees.Name AS EmployeeName, Employees_1.Name AS ManagerName FROM EmployeeAttendanceApprovals INNER JOIN Employees ON EmployeeAttendanceApprovals.EmpCode = Employees.EmpCode INNER JOIN Employees AS Employees_1 ON EmployeeAttendanceApprovals.Managerid = Employees_1.EmployeeAcc WHERE (EmployeeAttendanceApprovals.Status = 'Pending') AND (EmployeeAttendanceApprovals.Comid = '" + Session["Comid"] + "') AND (Employees_1.comid = '" + Session["Comid"] + "') AND (Employees.comid = '" + Session["Comid"] +"') ").ToList();
            var Approved = _context.Database.SqlQuery<EmployeeAttendaceApprovalVMQ>("SELECT EmployeeAttendanceApprovals.id, EmployeeAttendanceApprovals.EmpCode, EmployeeAttendanceApprovals.Managerid, EmployeeAttendanceApprovals.Status, EmployeeAttendanceApprovals.CheckInDatetime, EmployeeAttendanceApprovals.CheckOutDatetime, EmployeeAttendanceApprovals.Remarks, Employees.Name AS EmployeeName, Employees_1.Name AS ManagerName FROM EmployeeAttendanceApprovals INNER JOIN Employees ON EmployeeAttendanceApprovals.EmpCode = Employees.EmpCode INNER JOIN Employees AS Employees_1 ON EmployeeAttendanceApprovals.Managerid = Employees_1.EmployeeAcc WHERE (EmployeeAttendanceApprovals.Status = 'Approved') AND (EmployeeAttendanceApprovals.Comid = '" + Session["Comid"] + "') AND (Employees_1.comid = '" + Session["Comid"] + "') AND (Employees.comid = '" + Session["Comid"] + "') ").ToList();
            var Rejected = _context.Database.SqlQuery<EmployeeAttendaceApprovalVMQ>("SELECT EmployeeAttendanceApprovals.id, EmployeeAttendanceApprovals.EmpCode, EmployeeAttendanceApprovals.Managerid, EmployeeAttendanceApprovals.Status, EmployeeAttendanceApprovals.CheckInDatetime, EmployeeAttendanceApprovals.CheckOutDatetime, EmployeeAttendanceApprovals.Remarks, Employees.Name AS EmployeeName, Employees_1.Name AS ManagerName FROM EmployeeAttendanceApprovals INNER JOIN Employees ON EmployeeAttendanceApprovals.EmpCode = Employees.EmpCode INNER JOIN Employees AS Employees_1 ON EmployeeAttendanceApprovals.Managerid = Employees_1.EmployeeAcc WHERE (EmployeeAttendanceApprovals.Status = 'Rejected') AND (EmployeeAttendanceApprovals.Comid = '" + Session["Comid"] + "') AND (Employees_1.comid = '" + Session["Comid"] + "') AND (Employees.comid = '" + Session["Comid"] + "') ").ToList();
            var EmployeeAttendanceApprovalVM = new EmployeeAttendanceApprovalVM
            {
                Pending =pending,
                Rejected=Rejected,
                Approved= Approved,
            };
            return View(EmployeeAttendanceApprovalVM);
        }
        public ActionResult Create(EmployeeAttendance EmployeeAttendance)
        {
            int id = Convert.ToInt32(Session["Comid"]);
            var EmployeeAttendanceVM = new EmployeeAttendanceVM
            {
                EmployeeAttendance = EmployeeAttendance,
                EmployeeList = _context.Employee.Where(c => c.comid == id && c.EmployeeStatus == "Active").ToList(),
            };
            return View(EmployeeAttendanceVM);
        }
        public ActionResult Save(int[] Emp, string[] StDate, string[] EnDate,string[]Remarks,string Status)
        {
            for (int i = 0; i < Emp.Count(); i++)
            {
                if (StDate[i] != "")
                {
                    _context.Database.ExecuteSqlCommand("INSERT INTO EmployeeAttendances(EmpCode, Status, Datetime, Remarks ,Comid) VALUES ('"+ Emp[i] +"','In','"+ StDate[i] +"','"+ Remarks[i] +"','"+ Session["Comid"] +"') ");
                }
                else if(EnDate[i] != "")
                {
                    _context.Database.ExecuteSqlCommand("INSERT INTO EmployeeAttendances(EmpCode, Status, Datetime, Remarks,Comid) VALUES ('" + Emp[i] + "','Out','" + EnDate[i] + "','" + Remarks[i] + "','"+ Session["Comid"] +"') ");
                }
            }
            TempData["Insert"] = "Inserted Successfully";

            return RedirectToAction("Create");
        }
        public ActionResult Creates(EmployeeAttendanceApproval EmployeeAttendanceApproval)
        {
            int id = Convert.ToInt32(Session["Comid"]);
            var EmployeeAttendanceVM = new EmployeeAttendanceVM
            {
                EmployeeAttendanceApproval = EmployeeAttendanceApproval,
                EmployeeList = _context.Employee.Where(c => c.comid == id && c.EmployeeStatus == "Active").ToList(),
            };
            return View(EmployeeAttendanceVM);
        }
        public ActionResult Saves(string[] Emp, string StDateTime, string EnDateTime, string[] Remarks)
        {
            DateTime StDate = Convert.ToDateTime(StDateTime),EnDate = Convert.ToDateTime(EnDateTime);
            for (int i = 0; i < Emp.Count(); i++)
            {
                var Userid = _context.Database.SqlQuery<int>("SELECT USERINFO.USERID FROM USERINFO INNER JOIN Employees ON USERINFO.NAME = Employees.EmpCode WHERE(USERINFO.NAME = '" + Emp[i] + "')").SingleOrDefault();
                if (StDate.Year.ToString() != "1")
                {
                    _context.Database.ExecuteSqlCommand("INSERT INTO CHECKINOUT (USERID, CHECKTIME, Memoinfo) VALUES ('" + Userid + "','" + StDate + "','Attendance Adjustment') ");
                }
                if (EnDate.Year.ToString() != "1")
                {
                    _context.Database.ExecuteSqlCommand("INSERT INTO CHECKINOUT (USERID, CHECKTIME, Memoinfo) VALUES ('" + Userid + "','" + EnDate + "','Attendance Adjustment') ");
                }
            }
            TempData["Insert"] = "Inserted Successfully";

            return RedirectToAction("Creates");
        }
        public ActionResult Delete(int id)
        {
            var AttendaceRequest = _context.EmployeeAttendaceApproval.SingleOrDefault(c => c.id == id);
            _context.EmployeeAttendaceApproval.Remove(AttendaceRequest);
            _context.SaveChanges();
            TempData["Delete"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Status(int[] Emp, string Status, string Narr)
        {
            for (int i = 0; i < Emp.Count(); i++)
            {
                if (Status == "Approved")
                {
                    _context.Database.ExecuteSqlCommand("UPDATE EmployeeAttendanceApprovals SET  Status ='Approved' WHERE (id = '" + Emp[i] + "') ");
                    var dates = _context.Database.SqlQuery<EmployeeAttendanceApproval>("SELECT * FROM EmployeeAttendanceApprovals WHERE (id = '"+ Emp[i] +"') ").SingleOrDefault();
                    var Userid = _context.Database.SqlQuery<int>("SELECT USERINFO.USERID FROM USERINFO INNER JOIN Employees ON USERINFO.NAME = Employees.EmpCode WHERE(USERINFO.NAME = '"+ dates.EmpCode +"')").SingleOrDefault();
                    if (dates.CheckInDatetime.Year.ToString() != "1")
                    {
                        _context.Database.ExecuteSqlCommand("INSERT INTO CHECKINOUT (USERID, CHECKTIME, Memoinfo) VALUES ('" + Userid +"','"+ dates.CheckInDatetime + "','Attendance Adjustment') ");
                    }
                    if (dates.CheckOutDatetime.Year.ToString() != "1")
                    {
                        _context.Database.ExecuteSqlCommand("INSERT INTO CHECKINOUT (USERID, CHECKTIME, Memoinfo) VALUES ('" + Userid + "','" + dates.CheckOutDatetime + "','Attendance Adjustment') ");
                    }
                }
                else if(Status == "Rejected")
                {
                    _context.Database.ExecuteSqlCommand("UPDATE EmployeeAttendanceApprovals SET  Status ='Rejected' WHERE (id = '" + Emp[i] + "') ");
                }
                
            }
            TempData["Insert"] = "Query Executed Successfully";
            return RedirectToAction("Index");
        }

        //public ActionResult Saves(string[] Emp, DateTime[] StDate, DateTime[] EnDate, string[] Remarks, string Status)
        //{
        //    for (int i = 0; i < Emp.Count(); i++)
        //    {

        //        if (EnDate[i].Year.ToString() != "1" && StDate[i].Year.ToString() != "1")
        //        {
        //            var Manager = _context.Database.SqlQuery<int>("SELECT Managerid FROM Employees WHERE(EmpCode = '" + Emp[i] + "')").SingleOrDefault();
        //            _context.Database.ExecuteSqlCommand("INSERT INTO EmployeeAttendanceApprovals (EmpCode, Managerid, Status, CheckInDatetime, CheckOutDatetime, Remarks,Comid) VALUES ('" + Emp[i] + "','" + Manager + "','Pending','" + StDate[i] + "','" + EnDate[i] + "','" + Remarks[i] + "','" + Session["Comid"] + "') ");
        //        }
        //        else if (EnDate[i].Year.ToString() != "1" && StDate[i].Year.ToString() == "1")
        //        {
        //            var Manager = _context.Database.SqlQuery<int>("SELECT Managerid FROM Employees WHERE(EmpCode = '" + Emp[i] + "')").SingleOrDefault();
        //            _context.Database.ExecuteSqlCommand("INSERT INTO EmployeeAttendanceApprovals (EmpCode, Managerid, Status, CheckInDatetime, CheckOutDatetime, Remarks,Comid)" +
        //                " VALUES ('" + Emp[i] + "','" + Manager + "','Pending','0001-01-01 12:00:00 AM','" + EnDate[i] + "','" + Remarks[i] + "','" + Session["Comid"] + "') ");
        //        }
        //        else if (EnDate[i].Year.ToString() == "1" && StDate[i].Year.ToString() != "1")
        //        {
        //            var Manager = _context.Database.SqlQuery<int>("SELECT Managerid FROM Employees WHERE(EmpCode = '" + Emp[i] + "')").SingleOrDefault();
        //            _context.Database.ExecuteSqlCommand("INSERT INTO EmployeeAttendanceApprovals (EmpCode, Managerid, Status, CheckInDatetime, CheckOutDatetime, Remarks,Comid)" +
        //                " VALUES ('" + Emp[i] + "','" + Manager + "','Pending','" + StDate[i] + "','0001-01-01 12:00:00 AM','" + Remarks[i] + "','" + Session["Comid"] + "') ");
        //        }

        //    }
        //    TempData["Insert"] = "Inserted Successfully";

        //    return RedirectToAction("Creates");
        //}
    }
}