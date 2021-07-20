using PayRoll.Models;
using PayRoll.ViewModel;
using PayRoll.ViewModelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class RosAssignController : Controller
    {
        private ApplicationDbContext _context;
        public RosAssignController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: RosAssign
        public ActionResult Index()
        {
            var lst = _context.Database.SqlQuery<RsAssignVMQ>("SELECT RsAssigns.Shiftid,RsAssigns.DateTime, Shiftes.Name, Shiftes.StTime, Shiftes.EnTime, RsAssigns.RsAssignid FROM RsAssigns INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE (RsAssigns.Comid = '" + Session["Comid"] + "') AND (Shiftes.Comid = '" + Session["Comid"] +"')").OrderBy(c=> c.RsAssignid).ToList();
            return View(lst);
        }
        public ActionResult Create(RsAssign RsAssign)
        {
            int  Comid = Convert.ToInt32(Session["Comid"]);
            string dsa = "Ali";
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hashSh1 = sha1.ComputeHash(Encoding.UTF8.GetBytes(dsa));
                // declare stringbuilder
                var sb = new StringBuilder(hashSh1.Length * 2);

                // computing hashSh1
                foreach (byte b in hashSh1)
                {
                    // "x2"
                    sb.Append(b.ToString("X2").ToLower());
                }

                // final output
                Console.WriteLine(string.Format("The SHA1 hash of {0} is: {1}", dsa, sb.ToString()));
                string ab = sb.ToString();
            }
            
            var RsAssignChild = _context.RsAssignChild.SqlQuery("SELECT * FROM RsAssignChilds WHERE(Comid = " + Comid + ")").ToList();
            var RsAssignCreateVMQ = _context.Database.SqlQuery<RsAssignCreateVMQ>("SELECT ISNULL((SELECT TOP (1) LeaveDay FROM RsAssignChilds WHERE (EmpCode = Employees.EmpCode) AND (Comid = '" + Session["Comid"] + "') ORDER BY RsAssignid DESC), 'Null') AS LeaveDay, ISNULL ((SELECT TOP (1) Shiftes.Name FROM RsAssignChilds AS RsAssignChilds_1 INNER JOIN RsAssigns ON RsAssignChilds_1.RsAssignid = RsAssigns.RsAssignid INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE (RsAssignChilds_1.Comid = '" + Session["Comid"] + "') AND (RsAssigns.Comid = '" + Session["Comid"] + "') AND (RsAssignChilds_1.EmpCode = Employees.EmpCode) ORDER BY RsAssignChilds_1.RsAssignid DESC), 'Null') AS ShiftName, EmpCode, Name FROM Employees WHERE (comid = '" + Session["Comid"] +"') AND (EmployeeStatus = 'Active')").ToList();
            //var Employee = _context.Employee.SqlQuery("SELECT * FROM Employees WHERE(comid = '" + Session["Comid"] + "') AND (EmployeeStatus = 'Active') AND (EmpCode NOT IN (SELECT EmpCode FROM RsAssignChilds))").ToList();
            //var Roaster = _context.Roaster.SqlQuery("SELECT * FROM Roasters WHERE(comid = '" + Session["Comid"] +"')").ToList();
            var Shiftes = _context.Shiftes.SqlQuery("SELECT * FROM Shiftes WHERE(Comid = '" + Session["Comid"] + "')").ToList();
            var Day = _context.Days.ToList();
            var Viewmodel = new RsAssignVM
            {
                RsAssignCreateVMQ = RsAssignCreateVMQ,
                RsAssign =RsAssign,
                //EmployeeList=Employee,
                //RoasterList=Roaster,
                ShiftList=Shiftes,
                DayList=Day,
                RsAssignChildList=RsAssignChild,
            };
            return View(Viewmodel);
        }
        [HttpPost]
        public ActionResult Save(RsAssign RsAssign ,string[] Emp ,string[] Day)
        {
            string dir = "";
            if(RsAssign.id == 0)
            {
                RsAssign.RsAssignid = _context.Database.SqlQuery<int>("SELECT ISNULL(MAX(RsAssignid), 0) + 1 AS Expr1 FROM RsAssigns").SingleOrDefault(); 
                _context.Database.ExecuteSqlCommand("INSERT INTO RsAssigns (RsAssignid, Comid, Shiftid,DateTime) VALUES " +
                    "("+ RsAssign.RsAssignid +",'"+ Session["Comid"] +"','"+ RsAssign.Shiftid +"','"+ RsAssign.DateTime +"')");
                for (int i = 0; i < Emp.Count(); i++) 
                {
                    if (Day[i] != "")
                    {
                        _context.Database.ExecuteSqlCommand("INSERT INTO RsAssignChilds (RsAssignid, Comid, EmpCode, LeaveDay) VALUES " +
                            "(" + RsAssign.RsAssignid + ",'" + Session["Comid"] + "','" + Emp[i] + "','" + Day[i] + "') ");
                    }
                }
                TempData["Insert"] = "Query Excuted Successfully";
                dir = "Create";
            }
            else
            {
                    _context.Database.ExecuteSqlCommand("DELETE FROM RsAssignChilds WHERE(Comid = '" + Session["Comid"] + "') AND (RsAssignid = " + RsAssign.RsAssignid + ")");
                    _context.Database.ExecuteSqlCommand("DELETE FROM RsAssigns WHERE(Comid = '" + Session["Comid"] + "') AND (RsAssignid = " + RsAssign.RsAssignid + ")");
                    _context.Database.ExecuteSqlCommand("INSERT INTO RsAssigns (RsAssignid, Comid, Shiftid) VALUES " +
                        "(" + RsAssign.RsAssignid + ",'" + Session["Comid"] + "','" + RsAssign.Shiftid + "')");
                    for (int i = 0; i < Emp.Count(); i++)
                    {
                        if (Day[i] != "")
                        {
                            _context.Database.ExecuteSqlCommand("INSERT INTO RsAssignChilds (RsAssignid, Comid, EmpCode, LeaveDay) VALUES " +
                                "(" + RsAssign.RsAssignid + ",'" + Session["Comid"] + "','" + Emp[i] + "','" + Day[i] + "') ");
                        }
                    }
                    TempData["Update"] = "Updated Successfully";
                    dir = "Index";
            }
            return RedirectToAction(dir);
        }
        public ActionResult Edit(int id)
        {
            int Comid = Convert.ToInt32(Session["Comid"]);
            var RsAssignChild = _context.RsAssignChild.SqlQuery("SELECT * FROM RsAssignChilds WHERE(Comid = " + Comid + ") AND (RsAssignid = " + id + ")").ToList();
            var Employee = _context.Employee.SqlQuery("SELECT * FROM Employees WHERE(comid = '" + Session["Comid"] + "') AND (EmployeeStatus = 'Active')").ToList();
            //var Roaster = _context.Roaster.SqlQuery("SELECT * FROM Roasters WHERE(comid = '" + Session["Comid"] +"')").ToList();
            var Shiftes = _context.Shiftes.SqlQuery("SELECT * FROM Shiftes WHERE(Comid = '" + Session["Comid"] + "')").ToList();
            var Day = _context.Days.ToList();
            var RsAssign = _context.RsAssign.SingleOrDefault(c=> c.RsAssignid == id && c.Comid == Comid);
            var Viewmodel = new RsAssignVM
            {
                RsAssign = RsAssign,
                EmployeeList = Employee,
                //RoasterList=Roaster,
                ShiftList = Shiftes,
                DayList=Day,
                RsAssignChildList=RsAssignChild
            };
            return View("Create",Viewmodel);
        }
        public ActionResult Report(int[] Rsid)
        {
            string Assign_id = "";
            for (int i = 0; i < Rsid.Count(); i++)
            {
                Assign_id = Assign_id + "'" + Rsid[i] + "'";
                if (i != Rsid.Count() - 1)
                {
                    Assign_id = Assign_id + ",";
                }
            }
            var Shifts = _context.Database.SqlQuery<RsAssignShiftsVMQ>("SELECT RsAssigns.RsAssignid, RsAssigns.Shiftid, Shiftes.Name, Shiftes.StTime, Shiftes.EnTime FROM RsAssigns INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE(RsAssigns.Comid = '" + Session["Comid"] + "') AND (RsAssigns.RsAssignid IN ("+ Assign_id +")) AND (Shiftes.Comid = '" + Session["Comid"] +"')").ToList();
            var List = _context.Database.SqlQuery<RsAssignListVMQ>("SELECT RsAssignChilds.RsAssignid,RsAssignChilds.EmpCode, RsAssignChilds.LeaveDay, Employees.Name, Designations.Name AS Designation FROM RsAssignChilds INNER JOIN Employees ON RsAssignChilds.EmpCode = Employees.EmpCode INNER JOIN Designations ON Employees.Designationid = Designations.id WHERE(RsAssignChilds.Comid = '" + Session["Comid"] + "') AND (RsAssignChilds.RsAssignid IN (" + Assign_id +")) AND (Employees.comid = '" + Session["Comid"] + "') AND (Designations.Comid = '" + Session["Comid"] + "')").ToList();
            var Viewmodel = new RsAssignReportVM
            {
                RsAssignShiftsVMQList =Shifts,
                RsAssignChildList=List,
            };
            return View(Viewmodel);
        }
    }
}