using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class SalaryController : Controller
    {
        private ApplicationDbContext _context;
        public SalaryController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Salary
        public ActionResult Index()
        {
            return View(_context.SalarPackage.SqlQuery("SELECT * FROM SalaryPackages WHERE (Comid='"+ Session["Comid"] +"')").OrderByDescending(c => c.id).ToList());
        }
        public ActionResult Create(SalaryPackage SalaryPackage)
        {
            SalaryPackage.HouseRent = "0";
            SalaryPackage.MedicalAllowance = "0";
            SalaryPackage.BasicSalary = "0";
            return View(SalaryPackage);
        }
        [HttpPost]
        public ActionResult Save(SalaryPackage SalaryPackage)
        {
            string vardirection;
            if (SalaryPackage.id == 0)
            {
                SalaryPackage.Comid = Convert.ToInt32(Session["Comid"]);
                _context.SalarPackage.Add(SalaryPackage);
                vardirection = "create";
                TempData["Insert"] = "Inserted Successfully.";
            }
            else
            {
                var db = _context.SalarPackage.SingleOrDefault(c => c.id == SalaryPackage.id);
                db.Name = SalaryPackage.Name;
                db.BasicSalary = SalaryPackage.BasicSalary;
                db.MedicalAllowance = SalaryPackage.MedicalAllowance;
                db.HouseRent = SalaryPackage.HouseRent;
                db.Total = SalaryPackage.Total;
                vardirection = "Index";
                TempData["Update"] = "Updated Successfully.";
            }
            _context.SaveChanges();
            return RedirectToAction(vardirection);
        }
        public ActionResult Edit(int id)
        {
            var lst = _context.SalarPackage.SingleOrDefault(c => c.id == id);
            return View("Create", lst);
        }
    }
}