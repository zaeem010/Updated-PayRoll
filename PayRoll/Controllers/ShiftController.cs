using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class ShiftController : Controller
    {
        private ApplicationDbContext _context;

        public ShiftController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Shift
        public ActionResult Index()
        {
            return View(_context.Shiftes.SqlQuery("Select * FROM Shiftes WHERE (Comid ='"+ Session["Comid"] +"')").OrderByDescending(c=>c.id).ToList());
        }
        public ActionResult Create(Shiftes Shift)
        {
            return View(Shift);
        }
        [HttpPost]
        public ActionResult Save(Shiftes Shiftes, DateTime StTime,DateTime EnTime) 
        {
            string vardirection;
            if (Shiftes.id == 0)
            {
                Shiftes.Comid = Convert.ToInt32(Session["Comid"]);
                _context.Shiftes.Add(Shiftes);
                vardirection = "create";
                TempData["Insert"] = "Inserted Successfully.";
            }
            else
            {
                var db = _context.Shiftes.SingleOrDefault(c => c.id == Shiftes.id);
                db.Name = Shiftes.Name;
                db.StTime = StTime;
                db.EnTime = EnTime;
                db.EarlyStTimeinMin = Shiftes.EarlyStTimeinMin;
                db.LateStTimeinMin = Shiftes.LateStTimeinMin;
                db.EarlyEnTimeinMin = Shiftes.EarlyEnTimeinMin;
                db.LateEnTimeinMin = Shiftes.LateEnTimeinMin;
                db.ShiftHours = Shiftes.ShiftHours;
                vardirection = "Index";
                TempData["Update"] = "Updated Successfully.";
            }
            _context.SaveChanges();
            return RedirectToAction(vardirection);
        }
        public ActionResult Edit(int id)
        {
            var lst = _context.Shiftes.SingleOrDefault(c => c.id == id);
            return View("Create", lst);
        }
    }
}