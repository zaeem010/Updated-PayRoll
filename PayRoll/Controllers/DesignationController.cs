using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class DesignationController : Controller
    {
        private ApplicationDbContext _context;

        public DesignationController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Designation
        public ActionResult Index()
        {
            return View(_context.Designation.SqlQuery("SELECT * FROM Designations WHERE (Comid= '"+ Session["Comid"] +"')").OrderByDescending(c => c.id).ToList());
        }
        public ActionResult Create(Designation Designation)
        {
            return View(Designation);
        }
        [HttpPost]
        public ActionResult Save(Designation Designation)
        {
            string vardirection;
            if (Designation.id == 0)
            {
                Designation.Comid = Convert.ToInt32(Session["Comid"]);
                _context.Designation.Add(Designation);
                vardirection = "create";
                TempData["Insert"] = "Inserted Successfully.";
            }
            else
            {
                var db = _context.Designation.SingleOrDefault(c => c.id == Designation.id);
                db.Name = Designation.Name;
                vardirection = "Index";
                TempData["Update"] = "Updated Successfully.";
            }
            _context.SaveChanges();
            return RedirectToAction(vardirection);
        }
        public ActionResult Edit(int id)
        {
            var lst = _context.Designation.SingleOrDefault(c => c.id == id);
            return View("Create", lst);
        }
    }
}