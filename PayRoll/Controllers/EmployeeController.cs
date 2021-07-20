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
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _context;
        public int account_no1 { get; set; }
        public EmployeeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Employee
        public ActionResult Index()
        {
            var lst = _context.Database.SqlQuery<EmployeeVMQ>("SELECT Employees.id, Employees.Image, Employees.EmpCode, Employees.Name, Employees.DOB, Employees.Cnic, Employees.Branchid, Employees.Departid, Employees.EmployeeStatus, Designations.Name AS Designation, Departmentes.Name AS Depart, Roasters.Name AS Roaster, Employees.Phone FROM Employees INNER JOIN Designations ON Employees.Designationid = Designations.id INNER JOIN Departmentes ON Employees.Departid = Departmentes.id INNER JOIN Roasters ON Employees.Roasterid = Roasters.id WHERE(Employees.EmployeeStatus = 'Active') AND (Designations.Comid = '" + Session["Comid"] + "') AND (Employees.comid = '" + Session["Comid"] + "') AND (Departmentes.Comid = '" + Session["Comid"] + "') AND (Roasters.Comid = '" + Session["Comid"] +"')").ToList();
            return View(lst);
        }
        public ActionResult Create(Employee Employee)
        {
            var BranchList = _context.Branch.SqlQuery("SELECT * FROM Branches WHERE (id ='"+ Session["Comid"] +"')").ToList();
            var DepartList = _context.Departmentes.SqlQuery("Select * FROM Departmentes WHERE (Comid = '" + Session["Comid"] + "')").ToList();
            var DesignationList = _context.Designation.SqlQuery("Select * FROM Designations WHERE (Comid = '" + Session["Comid"] + "')").ToList();
            var LineManagerList = _context.Employee.SqlQuery("SELECT * FROM Employees WHERE (Designationid IN ('1', '5')) AND (Comid = '" + Session["Comid"] + "') AND (EmployeeStatus = 'Active')").ToList();
            var OTApprovalList = _context.Employee.SqlQuery("SELECT * FROM Employees WHERE (Designationid IN ('1', '5')) AND (Comid = '" + Session["Comid"] + "') AND (EmployeeStatus = 'Active')").ToList();
            var LeaveApprovalList = _context.Employee.SqlQuery("SELECT * FROM Employees WHERE (Designationid IN ('1', '5')) AND (Comid = '" + Session["Comid"] + "') AND (EmployeeStatus = 'Active')").ToList();
            var RoasterList = _context.Roaster.SqlQuery("Select * FROM Roasters WHERE (Comid = '" + Session["Comid"] + "')").ToList();
            var SalaryList = _context.SalarPackage.SqlQuery("SELECT * FROM SalaryPackages WHERE (Comid = '" + Session["Comid"] + "')").ToList();
            var ShiftList = _context.Shiftes.SqlQuery("SELECT * FROM Shiftes WHERE (Comid = '" + Session["Comid"] + "')").ToList();
            var BankList = _context.Bank.SqlQuery("Select * FROM Banks Where (Comid = '" + Session["Comid"] + "')").ToList();
            //Employee.GeneCode = _context.Database.SqlQuery<int>("SELECT ISNULL(MAX(GeneCode), 10001) + 1 AS Expr1 FROM Employees").SingleOrDefault();
            Employee.Branchid = 1;
            Employee.City = "Multan";
            Employee.Managerid = 2100001;
            Employee.Roasterid = 1;
            Employee.EmpQualification = "None";
            var viewmodel = new EmployeeVM
            {
                Employee=Employee,
                BranchList=BranchList,
                DepartList=DepartList,
                DesignationList=DesignationList,
                LineManagerList=LineManagerList,
                OTApprovalList= OTApprovalList,
                LeaveApprovalList= LeaveApprovalList,
                RoasterList=RoasterList,
                SalaryList=SalaryList,
                BankList=BankList,
                ShiftList=ShiftList,
            };
            return View(viewmodel);
        }
        public ActionResult Action(int id)
        {
            var Get = _context.Database.SqlQuery<SalaryPackage>("SELECT *  FROM   SalaryPackages WHERE (id = '" + id + "')").ToList();
            return Json(Get, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCode(int id)
        {
            var Get = _context.Database.SqlQuery<Branch>("SELECT * FROM Branches WHERE (id = '" + id + "')").ToList();
            return Json(Get, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetNum(int id)
        {
            int code = 0;
            //string Get = _context.Database.SqlQuery<string>("SELECT MAX(GeneCode)+ 1 AS Expr1 FROM Employees WHERE (Branchid = " + id +" )").SingleOrDefault();
            if (_context.Employee.Where(c => c.Branchid == id).Count() == 0)
            {
                 code = Convert.ToInt32(id.ToString() + "0001");
            }
            else
            {
                 code =  _context.Employee.Where(c => c.Branchid == id).Max(x => x.GeneCode) + 1;
            }
            return Json(code, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Save(Employee Employee, HttpPostedFileBase img,ThirdLevel ThirdLevel)
        {
            string vardirection;
            string ImageName = "";
            string ImageName2 = "";
            string physicalpath;
            Employee.EmployeeStatus = "Active";
            Employee.comid = Convert.ToInt32(Session["Comid"]);
            if (img != null)
            {
                ImageName = System.IO.Path.GetFileName(img.FileName);
                physicalpath = Server.MapPath("~/uploads/" + ImageName);
                img.SaveAs(physicalpath);
            }
            if (Employee.id == 0)
            {
                var Dup = _context.Database.SqlQuery<int>("SELECT COUNT(*) * 2 AS Count FROM Employees WHERE(Cnic = '"+ Employee.Cnic +"')").SingleOrDefault();
                var Block = _context.Database.SqlQuery<int>("SELECT COUNT(*) * 3 AS Count FROM Employees WHERE(Cnic = '" + Employee.Cnic + "') AND (EmployeeStatus = 'Block')").SingleOrDefault();
                var Resign = _context.Database.SqlQuery<int>("SELECT COUNT(*) * 4 AS Count FROM Employees WHERE(Cnic = '" + Employee.Cnic + "') AND (EmployeeStatus = 'Resign')").SingleOrDefault();
                if (Block == 3)
                {
                    Dup = 0;
                }else if (Resign == 4)
                {
                    Dup = 0;
                }
                if (Dup == 2 || Block == 3 || Resign == 4)
                {
                    var BranchList = _context.Branch.SqlQuery("SELECT * FROM Branches WHERE (id ='" + Session["Comid"] + "')").ToList();
                    var DepartList = _context.Departmentes.SqlQuery("Select * FROM Departmentes WHERE (Comid = '" + Session["Comid"] + "')").ToList();
                    var DesignationList = _context.Designation.SqlQuery("Select * FROM Designations WHERE (Comid = '" + Session["Comid"] + "')").ToList();
                    var LineManagerList = _context.Employee.SqlQuery("SELECT * FROM Employees WHERE (Designationid IN ('1', '5')) AND (Comid = '" + Session["Comid"] + "') AND (EmployeeStatus = 'Active')").ToList();
                    var OTApprovalList = _context.Employee.SqlQuery("SELECT * FROM Employees WHERE (Designationid IN ('1', '5')) AND (Comid = '" + Session["Comid"] + "') AND (EmployeeStatus = 'Active')").ToList();
                    var LeaveApprovalList = _context.Employee.SqlQuery("SELECT * FROM Employees WHERE (Designationid IN ('1', '5')) AND (Comid = '" + Session["Comid"] + "') AND (EmployeeStatus = 'Active')").ToList();
                    var RoasterList = _context.Roaster.SqlQuery("Select * FROM Roasters WHERE (Comid = '" + Session["Comid"] + "')").ToList();
                    var SalaryList = _context.SalarPackage.SqlQuery("SELECT * FROM SalaryPackages WHERE (Comid = '" + Session["Comid"] + "')").ToList();
                    var ShiftList = _context.Shiftes.SqlQuery("SELECT * FROM Shiftes WHERE (Comid = '" + Session["Comid"] + "')").ToList();
                    var BankList = _context.Bank.SqlQuery("Select * FROM Banks Where (Comid = '" + Session["Comid"] + "')").ToList();
                    var SalaryDup = _context.SalarPackage.SingleOrDefault(c=>c.id == Employee.salaryid);
                    //Employee.GeneCode = _context.Database.SqlQuery<int>("SELECT ISNULL(MAX(GeneCode), 10001) + 1 AS Expr1 FROM Employees").SingleOrDefault();
                    var viewmodel = new EmployeeVM
                    {
                        Employee = Employee,
                        BranchList = BranchList,
                        DepartList = DepartList,
                        DesignationList = DesignationList,
                        LineManagerList = LineManagerList,
                        OTApprovalList = OTApprovalList,
                        LeaveApprovalList = LeaveApprovalList,
                        RoasterList = RoasterList,
                        SalaryList = SalaryList,
                        BankList = BankList,
                        ShiftList = ShiftList,
                        SalaryDup = SalaryDup,
                        Code = 1,
                    };
                    if (Dup == 2 && Block == 0 && Resign == 0)
                    {
                        TempData["Dup"] = "The Employee With This Cnic Already Exists.";
                    }
                    else if (Dup == 0 && Block == 3 && Resign == 0)
                    {
                        TempData["Dup"] = "The Employee With This Cnic Has Been Blocked.";
                    }
                    else if (Dup == 0 && Block == 0 && Resign == 4)
                    {
                        TempData["Dup"] = "The Employee With This Cnic Has Resigned.";
                    }
                    return View("Create",viewmodel);
                }
                else 
                {
                    int code = 0;
                    string Code = _context.Database.SqlQuery<string>("SELECT BCode FROM Branches WHERE(id = " + Employee.Branchid + ")").SingleOrDefault();
                    if (_context.Employee.Where(c => c.Branchid == Employee.Branchid).Count() == 0)
                    {
                        code = Convert.ToInt32(Employee.Branchid.ToString() + "0001");
                    }
                    else
                    {
                        code = _context.Employee.Where(c => c.Branchid == Employee.Branchid).Max(x => x.GeneCode) + 1;
                    }
                    Employee.GeneCode = code;
                    Employee.EmpCode = "" + Code + "-" + code + "";

                    ThirdLevel.AccountNo = _context.Database.SqlQuery<int>("SELECT ISNULL(MAX(AccountNo), 0) as account_no FROM ThirdLevels where Headid = '2'").FirstOrDefault();
                    if (ThirdLevel.AccountNo == 0)
                    {
                        account_no1 = 2100001;
                    }
                    else
                    {
                        account_no1 = ThirdLevel.AccountNo + 1;
                    }
                    Employee.EmployeeAcc = account_no1;
                    Employee.Image = ImageName;
                    _context.Database.ExecuteSqlCommand("INSERT INTO ThirdLevels (AccountNo, Headid, SubHeadid, SecondHeadid, AccountTitle, AccountType, Dr, Cr,Comid) VALUES (" + Employee.EmployeeAcc + ",'2','2002','2000002','" + Employee.Name + "','Employee','0','0','"+ Session["Comid"] +"') ");
                    _context.Database.ExecuteSqlCommand("INSERT INTO USERINFO (Name) VALUES ('" + Employee.EmpCode + "') ");
                    _context.Employee.Add(Employee);
                    vardirection = "create";
                    TempData["Insert"] = "Inserted Successfully.";
                }
            }
            else
            {
                var db = _context.Employee.SingleOrDefault(c => c.id == Employee.id);
                ImageName2 = _context.Database.SqlQuery<string>("SELECT Image From Employees WHERE (id=" + Employee.id + ")").FirstOrDefault();
                if (ImageName != "")
                {
                    ImageName2 = ImageName;
                }
                //db.EmpCode = Employee.EmpCode;
                db.Title = Employee.Title;
                db.FName = Employee.FName;
                db.DOB = Employee.DOB;
                db.Gender = Employee.Gender;
                db.BloodGroup = Employee.BloodGroup;
                db.Cnic = Employee.Cnic;
                db.Address = Employee.Address;
                db.Phone = Employee.Phone;
                db.EmerPhone = Employee.EmerPhone;
                //db.Branchid = Employee.Branchid;
                db.Departid = Employee.Departid;
                db.Type = Employee.Type;
                db.Designationid = Employee.Designationid;
                db.Managerid = Employee.Managerid;
                db.Roasterid = Employee.Roasterid;
                db.overTime = Employee.overTime;
                //db.OTApproval = Employee.OTApproval;
                //db.LeaveApproval = Employee.LeaveApproval;
                db.JoiningDate = Employee.JoiningDate;
                db.idDetail = Employee.idDetail;
                db.LeaveCal = Employee.LeaveCal;
                db.salaryid = Employee.salaryid;
                db.BankInfo = Employee.BankInfo;
                db.PaymentTransfertype = Employee.PaymentTransfertype;
                db.offDay = Employee.offDay;
                db.NumberOfleaves = Employee.NumberOfleaves;
                db.AttendanceSandwitch = Employee.AttendanceSandwitch;
                db.BankAcc = Employee.BankAcc;
                db.Name = Employee.Name;
                db.City = Employee.City;
                db.EmpQualification = Employee.EmpQualification;
                //db.Shiftid = Employee.Shiftid;
                db.PerHourSalary = Employee.PerHourSalary;
                if (ImageName != "")
                {
                    db.Image = ImageName2;
                }
                _context.Database.ExecuteSqlCommand("UPDATE ThirdLevels Set AccountTitle ='"+ Employee.Name + "' WHERE (AccountNo = "+ db.EmployeeAcc +")");
                vardirection = "Index";
                TempData["Update"] = "Updated Successfully.";
            }
            _context.SaveChanges();
            return RedirectToAction(vardirection);
        }
        public ActionResult Edit(int id)
        {
            var Employee = _context.Employee.SingleOrDefault(c=>c.id == id);
            var BranchList = _context.Branch.SqlQuery("SELECT * FROM Branches WHERE (id ='" + Session["Comid"] + "')").ToList();
            var DepartList = _context.Departmentes.SqlQuery("Select * FROM Departmentes WHERE (Comid = '" + Session["Comid"] + "')").ToList();
            var DesignationList = _context.Designation.SqlQuery("Select * FROM Designations WHERE (Comid = '" + Session["Comid"] + "')").ToList();
            var LineManagerList = _context.Employee.SqlQuery("SELECT * FROM Employees WHERE (Designationid IN ('1', '5')) AND (Comid = '" + Session["Comid"] + "') AND (EmployeeStatus = 'Active')").ToList();
            var OTApprovalList = _context.Employee.SqlQuery("SELECT * FROM Employees WHERE (Designationid IN ('1', '5')) AND (Comid = '" + Session["Comid"] + "') AND (EmployeeStatus = 'Active')").ToList();
            var LeaveApprovalList = _context.Employee.SqlQuery("SELECT * FROM Employees WHERE (Designationid IN ('1', '5')) AND (Comid = '" + Session["Comid"] + "') AND (EmployeeStatus = 'Active')").ToList();
            var RoasterList = _context.Roaster.SqlQuery("Select * FROM Roasters WHERE (Comid = '" + Session["Comid"] + "')").ToList();
            var SalaryList = _context.SalarPackage.SqlQuery("SELECT * FROM SalaryPackages WHERE (Comid = '" + Session["Comid"] + "')").ToList();
            var ShiftList = _context.Shiftes.SqlQuery("SELECT * FROM Shiftes WHERE (Comid = '" + Session["Comid"] + "')").ToList();
            var BankList = _context.Bank.SqlQuery("Select * FROM Banks Where (Comid = '" + Session["Comid"] + "')").ToList();
            var SalaryPackage = _context.SalarPackage.SingleOrDefault(c=>c.id == Employee.salaryid);
            var viewmodel = new EmployeeVM
            {
                Employee = Employee,
                BranchList = BranchList,
                DepartList = DepartList,
                DesignationList = DesignationList,
                LineManagerList = LineManagerList,
                OTApprovalList = OTApprovalList,
                LeaveApprovalList = LeaveApprovalList,
                RoasterList = RoasterList,
                SalaryList = SalaryList,
                BankList = BankList,
                SalaryPackage=SalaryPackage,
                ShiftList=ShiftList,
            };
            return View("Create",viewmodel);
        }
        public ActionResult Update(string Emp, string St,string Date ,string Des)
        {
            if (St == "Block")
            {
                _context.Database.ExecuteSqlCommand("Update Employees Set EmployeeStatus= '"+ St + "',BlockNote='"+ Des + "' WHERE (EmpCode = '"+ Emp +"') ");
            }
            else if(St == "Resign")
            {
                _context.Database.ExecuteSqlCommand("Update Employees Set EmployeeStatus= '" + St + "',BlockNote='" + Des + "',ResignDate='"+ Date +"' WHERE (EmpCode = '" + Emp + "') ");
            }
            TempData["Status"] = "Status Updated SuccessFully";
            return RedirectToAction("Index");
        }
    }
}