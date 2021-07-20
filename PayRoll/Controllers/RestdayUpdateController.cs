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
    public class RestdayUpdateController : Controller
    {
        private ApplicationDbContext _context;

        public RestdayUpdateController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: RestdayUpdate
        public ActionResult Index(RestdayUpdate RestdayUpdate)
        {
            var VM = new RoasterUpdateVM
            {
                EmpForRoasterList = _context.Database.SqlQuery<EmpForRoaster>("SELECT EmpCode, Name, offDay AS RoasterName FROM Employees WHERE(EmployeeStatus = 'Active')AND (Comid='"+ Session["Comid"] +"') ").ToList(),
                RoasterList = _context.Roaster.ToList(),
                RestdayUpdate = RestdayUpdate,
            };
            return View(VM);
        }
        [HttpPost]
        public ActionResult Save(RestdayUpdate RestdayUpdate, string[] EmpCode)
        {
            RestdayUpdate.Date = DateTime.Now;
            for (int i = 0; i < EmpCode.Count(); i++)
            {
                _context.Database.ExecuteSqlCommand("INSERT  INTO RestdayUpdates(Restday, Date, EmpCode, Comid) VALUES" +
                    " ('" + RestdayUpdate.Restday + "','" + RestdayUpdate.Date + "','" + EmpCode[i] + "','" + Session["Comid"] + "')");
                _context.Database.ExecuteSqlCommand("UPDATE Employees SET offDay ='" + RestdayUpdate.Restday + "' WHERE ( EmpCode = '" + EmpCode[i] + "') ");
            }
            TempData["Insert"] = "Inserted Successfully";
            return RedirectToAction("Index");
        }
    }
}