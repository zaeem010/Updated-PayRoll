using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class OrgCalenderController : Controller
    {
        private ApplicationDbContext _context;

        public OrgCalenderController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: OrgCalender
        public ActionResult Index()
        {
            return View(_context.OrgCalender.SqlQuery("SELECT * FROM OrgCalenders WHERE (Comid='"+ Session["Comid"] +"')").OrderByDescending(c => c.id).ToList());
        }
        public ActionResult Create(OrgCalender OrgCalender)
        {
            return View(OrgCalender);
        }
        [HttpPost]
        public ActionResult Save(OrgCalender OrgCalender,string OT)
        {
            string vardirection;
            if (OrgCalender.id == 0)
            {
                OrgCalender.Comid = Convert.ToInt32(Session["Comid"]);
                _context.OrgCalender.Add(OrgCalender);
                vardirection = "create";
                TempData["Insert"] = "Inserted Successfully.";
            }
            else
            {
                var db = _context.OrgCalender.SingleOrDefault(c => c.id == OrgCalender.id);
                db.Name = OrgCalender.Name;
                db.StDate = OrgCalender.StDate;
                db.EnDate = OrgCalender.EnDate;
                db.OT = OrgCalender.OT;
                db.OTMBy = OrgCalender.OTMBy;
                vardirection = "Index";
                TempData["Update"] = "Updated Successfully.";
            }
            _context.SaveChanges();
            return RedirectToAction(vardirection);
        }
        public ActionResult Edit(int id)
        {
            var lst = _context.OrgCalender.SingleOrDefault(c => c.id == id);
            return View("Create", lst);
        }
    }
}