using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class RoasterController : Controller
    {
        private ApplicationDbContext _context;

        public RoasterController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Roaster
        public ActionResult Index()
        {
            return View(_context.Roaster.SqlQuery("Select * FROM Roasters WHERE (Comid = '"+ Session["Comid"] +"')").OrderByDescending(c=>c.id).ToList());
        }
        public ActionResult Create(Roaster Roaster)
        {
            return View(Roaster);
        }
        [HttpPost]
        public ActionResult Save(Roaster Roaster)
        {
            string vardirection;
            if (Roaster.id == 0)
            {
                Roaster.Comid = Convert.ToInt32(Session["Comid"]);
                _context.Roaster.Add(Roaster);
                vardirection = "create";
                TempData["Insert"] = "Inserted Successfully.";
            }
            else
            {
                var db = _context.Roaster.SingleOrDefault(c => c.id == Roaster.id);
                db.Name = Roaster.Name;
                db.Detail = Roaster.Detail;
                vardirection = "Index";
                TempData["Update"] = "Updated Successfully.";
            }
            _context.SaveChanges();
            return RedirectToAction(vardirection);
        }
        public ActionResult Edit(int id)
        {
            var lst = _context.Roaster.SingleOrDefault(c => c.id == id);
            return View("Create", lst);
        }
    }
}