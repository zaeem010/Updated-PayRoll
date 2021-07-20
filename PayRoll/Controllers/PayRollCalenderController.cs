using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class PayRollCalenderController : Controller
    {
        private ApplicationDbContext _context;

        public PayRollCalenderController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: PayRollCalender
        public ActionResult Index()
        {
            return View(_context.PayRollCalender.SqlQuery("Select * FROM PayRollCalenders WHERE (Comid ='"+ Session["Comid"] +"')").ToList());
        }
        public ActionResult Create(PayRollCalender PayRollCalender)
        {
            return View(PayRollCalender);
        }
        [HttpPost]
        public ActionResult Save(PayRollCalender PayRollCalender)
        {
            string vardirection;
            if (PayRollCalender.id == 0)
            {
                PayRollCalender.Comid = Convert.ToInt32(Session["Comid"]);
                _context.PayRollCalender.Add(PayRollCalender);
                vardirection = "create";
                TempData["Insert"] = "Inserted Successfully.";
            }
            else
            {
                var db = _context.PayRollCalender.SingleOrDefault(c => c.id == PayRollCalender.id);
                db.Name = PayRollCalender.Name;
                db.StDate = PayRollCalender.StDate;
                db.EnDate = PayRollCalender.EnDate;
                db.Detail = PayRollCalender.Detail;
                vardirection = "Index";
                TempData["Update"] = "Updated Successfully.";
            }
            _context.SaveChanges();
            return RedirectToAction(vardirection);
        }
        public ActionResult Edit(int id)
        {
            var lst = _context.PayRollCalender.SingleOrDefault(c => c.id == id);
            return View("Create", lst);
        }
    }
}