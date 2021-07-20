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
    public class AssignRoasterController : Controller
    {
        private ApplicationDbContext _context;
        public AssignRoasterController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: AssignRoaster
        public ActionResult Index()
        {

            var lst = _context.Database.SqlQuery<AssignRoasterVMQ>("SELECT AssignRoasters.Roasterid, Roasters.Name AS RoasterName FROM AssignRoasters INNER JOIN Roasters ON AssignRoasters.Roasterid = Roasters.id WHERE(AssignRoasters.Comid = '" + Session["Comid"] + "') AND (Roasters.Comid = '" + Session["Comid"] +"') GROUP BY AssignRoasters.Roasterid, Roasters.Name").ToList();
            var lsts = _context.Database.SqlQuery<AssignsRoasterVMQ>("SELECT AssignRoasters.Day, AssignRoasters.Roasterid, Shiftes.Name AS ShiftName FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE(AssignRoasters.Comid = '" + Session["Comid"] + "') AND (Shiftes.Comid = '" + Session["Comid"] + "')").ToList();
            var view = new AssignRoasterVM
            {
                AssignRoasterVMQList = lst,
                AssignsRoasterVMQList=lsts,
            };
            return View(view);
        }
        public ActionResult Create(AssignRoaster AssignRoaster)
        {
            var RoasterList = _context.Roaster.SqlQuery("SELECT * From Roasters Where (Comid = '" + Session["Comid"] + "')").ToList();
            var ShiftList = _context.Shiftes.SqlQuery("SELECT * FROM Shiftes Where (Comid = '" + Session["Comid"] + "')").ToList();
            var view = new AssignRoasterVM
            {
                AssignRoaster=AssignRoaster,
                RoasterList=RoasterList,
                ShiftList=ShiftList
            };
            return View(view);
        }
        [HttpPost]
        public ActionResult Save(AssignRoaster AssignRoaster ,string[] Day,string[] Shift)
        {
            AssignRoaster.Comid = Convert.ToInt32(Session["Comid"]);
            var dir = "";
            if (AssignRoaster.id == 0)
            {
                for (int i = 0; i < Day.Count(); i++)
                {
                    _context.Database.ExecuteSqlCommand("INSERT INTO AssignRoasters(Day, Roasterid, Shiftid,Comid) VALUES ('"+ Day[i] +"','"+ AssignRoaster.Roasterid +"','"+ Shift[i] +"','"+ AssignRoaster.Comid +"')");
                }
                TempData["Insert"] = "Inserted Successfully";
                dir = "Create";
            }
            else
            {
                _context.Database.ExecuteSqlCommand("DELETE FROM AssignRoasters WHERE (Roasterid =" + AssignRoaster.Roasterid +") AND (Comid = '"+ Session["Comid"] +"')");
                for (int i = 0; i < Day.Count(); i++)
                {
                    _context.Database.ExecuteSqlCommand("INSERT INTO AssignRoasters(Day, Roasterid, Shiftid,Comid) VALUES ('" + Day[i] + "','" + AssignRoaster.Roasterid + "','" + Shift[i] + "','" + AssignRoaster.Comid + "')");
                }
                dir = "Index";
                TempData["Update"] = "Updated Successfully";
            }
                return RedirectToAction(dir);
        }
        public ActionResult Edit(int id ,AssignRoaster AssignRoaster)
        {
            var Assignroaster = _context.Database.SqlQuery<int>("SELECT Roasterid FROM AssignRoasters WHERE(Roasterid = "+ id + ") AND (Comid = '" + Session["Comid"] + "') GROUP BY Roasterid").SingleOrDefault();
            var Monday = _context.Database.SqlQuery<int>("SELECT Shiftid FROM AssignRoasters WHERE (Day = 'Monday') AND (Roasterid = "+ id + ") AND (Comid = '" + Session["Comid"] + "')").SingleOrDefault();
            var Tuesday = _context.Database.SqlQuery<int>("SELECT Shiftid FROM AssignRoasters WHERE (Day = 'Tuesday') AND (Roasterid = " + id + ") AND (Comid = '" + Session["Comid"] + "')").SingleOrDefault();
            var Wednesday = _context.Database.SqlQuery<int>("SELECT Shiftid FROM AssignRoasters WHERE (Day = 'Wednesday') AND (Roasterid = " + id + ") AND (Comid = '" + Session["Comid"] + "')").SingleOrDefault();
            var Thursday = _context.Database.SqlQuery<int>("SELECT Shiftid FROM AssignRoasters WHERE (Day = 'Thursday') AND (Roasterid = " + id + ") AND (Comid = '" + Session["Comid"] + "')").SingleOrDefault();
            var Friday = _context.Database.SqlQuery<int>("SELECT Shiftid FROM AssignRoasters WHERE (Day = 'Friday') AND (Roasterid = " + id + ") AND (Comid = '" + Session["Comid"] + "')").SingleOrDefault();
            var Saturday = _context.Database.SqlQuery<int>("SELECT Shiftid FROM AssignRoasters WHERE (Day = 'Saturday') AND (Roasterid = " + id + ") AND (Comid = '" + Session["Comid"] + "')").SingleOrDefault();
            var Sunday = _context.Database.SqlQuery<int>("SELECT Shiftid FROM AssignRoasters WHERE (Day = 'Sunday') AND (Roasterid = " + id + ") AND (Comid = '" + Session["Comid"] + "')").SingleOrDefault();
            var RoasterList = _context.Roaster.SqlQuery("SELECT * From Roasters Where (Comid = '" + Session["Comid"] + "')").ToList();
            var ShiftList = _context.Shiftes.SqlQuery("SELECT * FROM Shiftes Where (Comid = '" + Session["Comid"] + "')").ToList();
            AssignRoaster.Roasterid = Assignroaster;
            AssignRoaster.id = 1;
            var view = new AssignRoasterVM
            {
                AssignRoaster = AssignRoaster,
                RoasterList = RoasterList,
                ShiftList = ShiftList,
                Monday=Monday,
                Tuesday=Tuesday,
                Wednesday=Wednesday,
                Thursday=Thursday,
                Friday=Friday,
                Saturday=Saturday,
                Sunday=Sunday,
            };
            return View("Create",view);
        }
        
    }
}