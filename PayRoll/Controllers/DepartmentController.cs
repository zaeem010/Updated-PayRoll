using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class DepartmentController : Controller
    {
        private ApplicationDbContext _context;

        public DepartmentController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Department
        public ActionResult Index()
        {
            return View(_context.Departmentes.SqlQuery("SELECT * FROM Departmentes Where (Comid = '" + Session["Comid"] + "')").OrderByDescending(c => c.id).ToList());
        }
        public ActionResult Create(Departmentes Departmentes)
        {
            return View(Departmentes);
        }
        [HttpPost]
        public ActionResult Save(Departmentes Departmentes)
        {
            string vardirection;
            if (Departmentes.id == 0)
            {
                Departmentes.Comid = Convert.ToInt32(Session["Comid"]);
                _context.Departmentes.Add(Departmentes);
                vardirection = "create";
                TempData["Insert"] = "Inserted Successfully.";
            }
            else
            {
                var db = _context.Departmentes.SingleOrDefault(c => c.id == Departmentes.id);
                db.Name = Departmentes.Name;
                vardirection = "Index";
                TempData["Update"] = "Updated Successfully.";
            }
            _context.SaveChanges();
            return RedirectToAction(vardirection);
        }
        public ActionResult Edit(int id)
        {
            var lst = _context.Departmentes.SingleOrDefault(c => c.id == id);
            return View("Create", lst);
        }
    }
}