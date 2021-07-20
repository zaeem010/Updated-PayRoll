using PayRoll.Models;
using PayRoll.ViewModelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    [SessionTimeout]
    public class MonthlySalaryController : Controller
    {
        private ApplicationDbContext _context;
        public MonthlySalaryController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: MonthlySalary
        public ActionResult Index()
        {
            //var Listist = _context.Database.SqlQuery<MonthlySalaryVMQ>("SELECT Employees.EmpCode, Employees.Name, SalaryPackages.Total FROM Employees INNER JOIN SalaryPackages ON Employees.salaryid = SalaryPackages.id WHERE(Employees.comid = '"+ Session["Comid"] +"') AND (Employees.EmployeeStatus = 'Active')").ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Search(string Type)
        {
            var List = _context.Employee.SqlQuery("SELECT * FROM Employees WHERE (Type = '"+ Type +"') AND (EmployeeStatus = 'Active')").ToList();
            return View(List);
        }
        [HttpPost]
        public ActionResult GetSearch(string[] Emp,DateTime Month)
        {
            string new_Emp = "";
            for (int i = 0; i < Emp.Count(); i++)
            {
                new_Emp = new_Emp + "'" + Emp[i] + "'";
                if (i != Emp.Count() - 1)
                {
                    new_Emp = new_Emp + ",";
                }
            }
            var now = Month;
            int daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
            var firstDay = new DateTime(now.Year, now.Month, 1);
            var lastDay = new DateTime(now.Year, now.Month, daysInMonth);
            var allDates = new List<DateTime>();
            while (firstDay <= lastDay)
            {
                allDates.Add(firstDay);
                firstDay = firstDay.AddDays(1);
            }
            int RestdaysCount = 0;
            var Lists = _context.Database.SqlQuery<MonthlySalaryReportVMQ>("SELECT Employees.Name, Employees.EmpCode, USERINFO.USERID,(SELECT COUNT(*) AS Presentdays FROM EmployeeAttendanceReports WHERE (CONVERT(varchar(7), Date, 126) = '" + Month.ToString("yyyy-MM") + "') AND (EmpCode = USERINFO.USERID) AND (Final <> 'Absent')) AS Presentdays, (SELECT COUNT(*) AS AbsentDays FROM EmployeeAttendanceReports AS EmployeeAttendanceReports_1 WHERE (CONVERT(varchar(7), Date, 126) = '" + Month.ToString("yyyy-MM") + "') AND (EmpCode = USERINFO.USERID) AND (Final = 'Absent')) AS AbsentDays, (SELECT DAY(EOMONTH('" + Month.ToString("yyyy-MM-dd") + "')) AS Expr1) AS MonthDays, SalaryPackages.Total FROM Employees INNER JOIN USERINFO ON Employees.EmpCode = USERINFO.NAME INNER JOIN SalaryPackages ON Employees.salaryid = SalaryPackages.id WHERE (Employees.EmpCode IN (" + new_Emp +"))").ToList();
            List<MonthlySalaryAddRestReportVMQ> _SecondList = new List<MonthlySalaryAddRestReportVMQ>();
            foreach (var FirstList in Lists.ToList())
            {
                string RestDay =_context.Database.SqlQuery<string>("SELECT offDay FROM Employees WHERE (EmpCode = '"+ FirstList.EmpCode +"')").SingleOrDefault() ;
                for (int j= 0; j<allDates.Count(); j++)
                {
                    if (allDates[j].DayOfWeek.ToString() == RestDay)
                    {
                        RestdaysCount += 1;
                    }
                }
                int w_day = FirstList.Presentdays + RestdaysCount;
                _SecondList.Add(new MonthlySalaryAddRestReportVMQ 
                {
                    EmpCode = FirstList.EmpCode, 
                    Name = FirstList.Name,
                    USERID = FirstList.USERID,
                    Presentdays = FirstList.Presentdays,
                    Absentdays = FirstList.Monthdays - w_day,
                    Monthdays = FirstList.Monthdays,
                    Workingdays = w_day,
                    Restdays = RestdaysCount,
                    salary= (Convert.ToInt32(FirstList.Total)/ FirstList.Monthdays)* w_day
                }) ;
                RestdaysCount = 0;
            }
            return View(_SecondList);
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}