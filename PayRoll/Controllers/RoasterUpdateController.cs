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
    public class RoasterUpdateController : Controller
    {
        private ApplicationDbContext _context;

        public RoasterUpdateController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET: RoasterUpdate
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(RoasterUpdate RoasterUpdate)
        {
            var VM = new RoasterUpdateVM
            {
                EmpForRoasterList = _context.Database.SqlQuery<EmpForRoaster>("SELECT Employees.EmpCode, Employees.Name, Roasters.Name AS RoasterName FROM Employees INNER JOIN Roasters ON Employees.Roasterid = Roasters.id WHERE(Roasters.Comid = '"+ Session["Comid"] +"') AND (Employees.EmployeeStatus = 'Active')").ToList(),
                RoasterList =_context.Roaster.ToList(),
                RoasterUpdate= RoasterUpdate,
            };
            return View(VM);
        }
        [HttpPost]
        public ActionResult Save(RoasterUpdate RoasterUpdate,string [] EmpCode)
        {
            RoasterUpdate.Date = DateTime.Now;
            for (int i = 0; i < EmpCode.Count(); i++) 
            {
                _context.Database.ExecuteSqlCommand("INSERT  INTO RoasterUpdates(Roasterid, Date, EmpCode, Comid) VALUES" +
                    " ('"+ RoasterUpdate.Roasterid +"','"+ RoasterUpdate.Date +"','"+ EmpCode[i] +"','"+ Session["Comid"] +"')");
                _context.Database.ExecuteSqlCommand("UPDATE Employees SET Roasterid='"+ RoasterUpdate.Roasterid +"' WHERE ( EmpCode = '"+ EmpCode[i] +"') ");
            }
            TempData["Insert"] = "Inserted Successfully";
            return RedirectToAction("Create");
        }
    }
}