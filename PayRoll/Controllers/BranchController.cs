using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class BranchController : Controller
    {
        private ApplicationDbContext _context;

        public BranchController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Branch
        public ActionResult Index()
        {
            return View(_context.Branch.OrderBy(c => c.id).ToList());
        }
        public ActionResult Create(Branch Branch)
        {
            return View(Branch);
        }
        [HttpPost]
        public ActionResult Save(Branch Branch,HttpPostedFileBase img)
        {
            string vardirection;
            string ImageName = "";
            string ImageName2 = "";
            string physicalpath;
            if (img != null)
            {
                ImageName = System.IO.Path.GetFileName(img.FileName);
                physicalpath = Server.MapPath("~/uploads/" + ImageName);
                img.SaveAs(physicalpath);
            }
            if (Branch.id == 0)
            {
                Branch.BLogo = ImageName;
              _context.Branch.Add(Branch);
                vardirection = "create";
                TempData["Insert"] = "Inserted Successfully.";
            }
            else
            {
                var db = _context.Branch.SingleOrDefault(c => c.id == Branch.id);
                ImageName2 = _context.Database.SqlQuery<string>("SELECT Blogo From Branches WHERE (id="+ Branch.id +")").FirstOrDefault();
                if (ImageName != "")
                {
                    ImageName2 = ImageName;
                }
                db.Name = Branch.Name;
                db.City = Branch.City;
                db.Address = Branch.Address;
                db.BCode = Branch.BCode;
                if (ImageName != "")
                {
                    db.BLogo = ImageName2;
                }
                vardirection = "Index";
                TempData["Update"] = "Updated Successfully.";
            }
            _context.SaveChanges();
            return RedirectToAction(vardirection);
        }
        public ActionResult Edit(int id)
        {
            var lst = _context.Branch.SingleOrDefault(c => c.id == id);
            return View("Create",lst);
        }
    }
}