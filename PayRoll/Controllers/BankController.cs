using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class BankController : Controller
    {
        private ApplicationDbContext _context;

        public BankController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Bank
        public ActionResult Index()
        {
            return View(_context.Bank.SqlQuery("Select * from Banks Where (Comid = '"+Session["Comid"]+"')").ToList());
        }
        public ActionResult Create(Bank Bank)
        {
            return View(Bank);
        }
        [HttpPost]
        public ActionResult Save(Bank Bank)
        {
            string vardirection;
            if (Bank.id == 0)
            {
                Bank.Comid = Convert.ToInt32(Session["Comid"]);
                _context.Bank.Add(Bank);
                vardirection = "create";
                TempData["Insert"] = "Inserted Successfully.";
            }
            else
            {
                var db = _context.Bank.SingleOrDefault(c => c.id == Bank.id);
                db.Name = Bank.Name;
                db.BCode = Bank.BCode;
                db.City = Bank.City;
                db.Address = Bank.Address;
                vardirection = "Index";
                TempData["Update"] = "Updated Successfully.";
            }
            _context.SaveChanges();
            return RedirectToAction(vardirection);
        }
        public ActionResult Edit(int id)
        {
            var lst = _context.Bank.SingleOrDefault(c => c.id == id);
            return View("Create", lst);
        }
    }
}