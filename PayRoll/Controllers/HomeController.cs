using PayRoll.Models;
using PayRoll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PayRoll.Controllers
{
    [SessionTimeout]
    public class SessionTimeoutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["UserID"] == null)
            {
                filterContext.Result = new RedirectResult("~/Home/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            Session.Timeout = 30;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(UserLogin UserLogin)
        {
            var lst = _context.Branch.ToList();
            var viewmodel = new LoginVM
            {
                UserLogin=UserLogin,
                BranchList = lst,
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserAccess userAccess, UserLogin UserLogin)
        {
            string dir = "";
            if (ModelState.IsValid)
            {
                var obj = _context.Database.SqlQuery<UserLogin>("SELECT * FROM UserLogins WHERE UserName='" + UserLogin.UserName + "' AND Password ='" + UserLogin.Password + "' AND Comid = '"+ UserLogin.Comid +"' ").FirstOrDefault();
                if (obj != null)
                {
                    Session["UserID"] = obj.id;
                    Session["Comid"] = obj.Comid;
                    Session["UserName"] = obj.UserName.ToString();
                    dir = "Index";
                }
                else
                {
                    TempData["Invalid"] = "Invalid Login Details";
                    dir = "Login";
                }
            }
            return RedirectToAction(dir);
        }
        public ActionResult LogOut()
        {
            Session["UserID"] = null;
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();

            return RedirectToAction("Login");
        }
    }
}