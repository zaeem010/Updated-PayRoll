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
    public class OTRequestController : Controller
    {
        private ApplicationDbContext _context;
        public OTRequestController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: OTRequest
        public ActionResult Index()
        {
            var pending = _context.Database.SqlQuery<OTApprovalVMQ>("SELECT OTRequests.id,OTRequests.Managerid, OTRequests.StDate, OTRequests.Narration, OTRequests.EnDate, OTRequests.Status, Employees.Name AS EmployeeName, Employees_1.Name AS ManagerName, OTRequests.EmployeeAcc FROM OTRequests INNER JOIN Employees ON OTRequests.EmployeeAcc = Employees.EmployeeAcc INNER JOIN Employees AS Employees_1 ON OTRequests.Managerid = Employees_1.EmployeeAcc WHERE (OTRequests.Status = 'Pending') AND (OTRequests.Comid = '" + Session["Comid"] + "') AND (Employees_1.comid = '" + Session["Comid"] + "') AND (Employees.comid = '" + Session["Comid"] +"')").ToList();
            var Approved = _context.Database.SqlQuery<OTApprovalVMQ>("SELECT OTRequests.id,OTRequests.Managerid, OTRequests.StDate, OTRequests.EnDate, OTRequests.Narration, OTRequests.Status, Employees.Name AS EmployeeName, Employees_1.Name AS ManagerName, OTRequests.EmployeeAcc FROM OTRequests INNER JOIN Employees ON OTRequests.EmployeeAcc = Employees.EmployeeAcc INNER JOIN Employees AS Employees_1 ON OTRequests.Managerid = Employees_1.EmployeeAcc WHERE (OTRequests.Status = 'Approved') AND (OTRequests.Comid = '" + Session["Comid"] + "') AND (Employees_1.comid = '" + Session["Comid"] + "') AND (Employees.comid = '" + Session["Comid"] + "')").ToList();
            var Rejected = _context.Database.SqlQuery<OTApprovalVMQ>("SELECT OTRequests.id,OTRequests.Managerid, OTRequests.StDate, OTRequests.EnDate, OTRequests.Narration, OTRequests.Status, Employees.Name AS EmployeeName, Employees_1.Name AS ManagerName, OTRequests.EmployeeAcc FROM OTRequests INNER JOIN Employees ON OTRequests.EmployeeAcc = Employees.EmployeeAcc INNER JOIN Employees AS Employees_1 ON OTRequests.Managerid = Employees_1.EmployeeAcc WHERE (OTRequests.Status = 'Rejected') AND (OTRequests.Comid = '" + Session["Comid"] + "') AND (Employees_1.comid = '" + Session["Comid"] + "') AND (Employees.comid = '" + Session["Comid"] + "')").ToList();
            var OTApprovalVM = new OTApprovalVM
            {
                Pending = pending,
                Approved=Approved,
                Rejected=Rejected,
            };
            return View(OTApprovalVM);
        }
        public ActionResult Create(OTRequest OTRequest)
        {
            int id = Convert.ToInt32(Session["Comid"]);
            var EmployeeList = _context.Employee.Where(c => c.comid == id && c.EmployeeStatus == "Active").ToList();
            var view = new OTRequestVM
            {
                OTRequest = OTRequest,
                EmployeeList=EmployeeList,
            };
            return View(view);
        }
        [HttpPost]
        public ActionResult Save(int[] Emp ,string[] StDate,string[] EnDate)
        {
            var dir = "";
            for (int i = 0; i < Emp.Count(); i++)
            {
                if (StDate[i] != "" && EnDate[i] != "")
                {
                    var Manager = _context.Database.SqlQuery<int>("SELECT Managerid FROM Employees WHERE(EmployeeAcc = " + Emp[i] + ")").SingleOrDefault();
                    _context.Database.ExecuteSqlCommand("INSERT  INTO OTRequests(EmployeeAcc, Managerid, StDate, EnDate, Status,Comid) VALUES (" + Emp[i] + ",'" + Manager + "','" + StDate[i] + "','" + EnDate[i] + "','Pending','"+ Session["Comid"] +"') ");
                }
            }
            TempData["Insert"] = "Inserted Successfully";
            dir = "Create";
            return RedirectToAction(dir);
        }
        [HttpPost]
        public ActionResult Status(int[] Emp, string Status,string Narr)
        {
            for (int i = 0; i < Emp.Count(); i++)
            {
            _context.Database.ExecuteSqlCommand("Update OTRequests SET Status='"+ Status +"', Narration ='"+ Narr +"' WHERE (EmployeeAcc ="+ Emp[i] +")");
            }
            TempData["Insert"] = "Query Executed Successfully";
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var oTRequest= _context.OTRequest.SingleOrDefault(c=>c.id==id);
            _context.OTRequest.Remove(oTRequest);
            _context.SaveChanges();
            TempData["Delete"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}