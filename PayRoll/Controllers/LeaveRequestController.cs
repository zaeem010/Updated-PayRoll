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
    public class LeaveRequestController : Controller
    {
        private ApplicationDbContext _context;
        public LeaveRequestController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: LeaveRequest
        public ActionResult Index()
        {
            var pending = _context.Database.SqlQuery<LeaveApprovalVMQ>("SELECT LeaveRequests.id, LeaveRequests.EmployeeAcc, LeaveRequests.Managerid, LeaveRequests.StDate, LeaveRequests.EnDate, LeaveRequests.Status, LeaveRequests.Narration, Employees.Name AS EmployeeName, Employees_1.Name AS ManagerName FROM LeaveRequests INNER JOIN Employees ON LeaveRequests.EmployeeAcc = Employees.EmployeeAcc INNER JOIN Employees AS Employees_1 ON LeaveRequests.Managerid = Employees_1.EmployeeAcc WHERE(LeaveRequests.Status = 'Pending')  AND (Employees.comid = '" + Session["Comid"] + "') AND (Employees_1.comid = '" + Session["Comid"] + "') AND (LeaveRequests.comid = '" + Session["Comid"] +"') ").ToList();
            var Approved = _context.Database.SqlQuery<LeaveApprovalVMQ>("SELECT LeaveRequests.id, LeaveRequests.EmployeeAcc, LeaveRequests.Managerid, LeaveRequests.StDate, LeaveRequests.EnDate, LeaveRequests.Status, LeaveRequests.Narration, Employees.Name AS EmployeeName, Employees_1.Name AS ManagerName FROM LeaveRequests INNER JOIN Employees ON LeaveRequests.EmployeeAcc = Employees.EmployeeAcc INNER JOIN Employees AS Employees_1 ON LeaveRequests.Managerid = Employees_1.EmployeeAcc WHERE(LeaveRequests.Status = 'Approved') AND (Employees.comid = '" + Session["Comid"] + "') AND (Employees_1.comid = '" + Session["Comid"] + "') AND (LeaveRequests.comid = '" + Session["Comid"] + "') ").ToList();
            var Rejected = _context.Database.SqlQuery<LeaveApprovalVMQ>("SELECT LeaveRequests.id, LeaveRequests.EmployeeAcc, LeaveRequests.Managerid, LeaveRequests.StDate, LeaveRequests.EnDate, LeaveRequests.Status, LeaveRequests.Narration, Employees.Name AS EmployeeName, Employees_1.Name AS ManagerName FROM LeaveRequests INNER JOIN Employees ON LeaveRequests.EmployeeAcc = Employees.EmployeeAcc INNER JOIN Employees AS Employees_1 ON LeaveRequests.Managerid = Employees_1.EmployeeAcc WHERE(LeaveRequests.Status = 'Rejected') AND (Employees.comid = '" + Session["Comid"] + "') AND (Employees_1.comid = '" + Session["Comid"] + "') AND (LeaveRequests.comid = '" + Session["Comid"] + "') ").ToList();
            var OTApprovalVM = new LeaveApprovalVM
            {
                Pending = pending,
                Approved = Approved,
                Rejected = Rejected,
            };
            return View(OTApprovalVM);
        }
        public ActionResult Create(LeaveRequest LeaveRequest)
        {
            int id = Convert.ToInt32(Session["Comid"]);
            var EmployeeList = _context.Employee.Where(c=> c.comid == id && c.EmployeeStatus == "Active").ToList();
            var view = new LeaveRequestVM
            {
                LeaveRequest = LeaveRequest,
                EmployeeList = EmployeeList,
            };
            return View(view);
        }
        [HttpPost]
        public ActionResult Save(int[] Emp, string[] StDate, string[] EnDate)
        {
            var dir = "";
            for (int i = 0; i < Emp.Count(); i++)
            {
                if (StDate[i] != "" && EnDate[i] != "")
                {
                    var Manager = _context.Database.SqlQuery<int>("SELECT Managerid FROM Employees WHERE(EmployeeAcc = " + Emp[i] + ")").SingleOrDefault();
                    _context.Database.ExecuteSqlCommand("INSERT  INTO LeaveRequests (EmployeeAcc, Managerid, StDate, EnDate, Status,Comid) VALUES (" + Emp[i] + ",'" + Manager + "','" + StDate[i] + "','" + EnDate[i] + "','Pending','"+ Session["Comid"] +"') ");
                }
            }
            TempData["Insert"] = "Inserted Successfully";
            dir = "Create";
            return RedirectToAction(dir);
        }
        [HttpPost]
        public ActionResult Status(int[] Emp, string Status, string Narr)
        {
            for (int i = 0; i < Emp.Count(); i++)
            {
                _context.Database.ExecuteSqlCommand("Update LeaveRequests SET Status='" + Status + "', Narration ='" + Narr + "' WHERE (EmployeeAcc =" + Emp[i] + ") AND (Comid ='"+ Session["Comid"] +"' )");
            }
            TempData["Insert"] = "Query Executed Successfully";
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var LeaveRequest = _context.LeaveRequest.SingleOrDefault(c => c.id == id);
            _context.LeaveRequest.Remove(LeaveRequest);
            _context.SaveChanges();
            TempData["Delete"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}