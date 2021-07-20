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
    public class EmployeeReportController : Controller
    {
        private ApplicationDbContext _context;
        public EmployeeReportController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: EmployeeReport
        public ActionResult Index()
        {
            var EmployeeList = _context.Employee.SqlQuery("SELECT * FROM Employees WHERE (Comid = '" + Session["Comid"] + "') AND (EmployeeStatus = 'Active')").ToList();
            var PayRollCalender = _context.PayRollCalender.SqlQuery("SELECT * FROM PayRollCalenders WHERE (Comid = '" + Session["Comid"] + "')").ToList();
            var EmployeeReportVM = new EmployeeReportVM
            {
                EmployeeList = EmployeeList,
                PayRollCalenderList = PayRollCalender,
            };
            return View(EmployeeReportVM);
        }
        public ActionResult Search(int Calender, string Emp)
        {
            var Userid = _context.Database.SqlQuery<int>("SELECT USERINFO.USERID FROM USERINFO INNER JOIN Employees ON USERINFO.NAME = Employees.EmpCode WHERE(USERINFO.NAME = '" + Emp + "')").SingleOrDefault();
            var RestDay = _context.Database.SqlQuery<string>("SELECT TOP(1) RsAssignChilds.LeaveDay FROM RsAssignChilds INNER JOIN RsAssigns ON RsAssignChilds.RsAssignid = RsAssigns.RsAssignid INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE (RsAssignChilds.EmpCode = '" + Emp + "') AND (RsAssignChilds.Comid = '" + Session["Comid"] + "') AND (RsAssigns.Comid = '" + Session["Comid"] + "') AND (Shiftes.Comid = '" + Session["Comid"] + "') ORDER BY RsAssignChilds.RsAssignid DESC").SingleOrDefault();
            var Shiftid = _context.Database.SqlQuery<int>("SELECT TOP(1) Shiftes.id FROM RsAssignChilds INNER JOIN RsAssigns ON RsAssignChilds.RsAssignid = RsAssigns.RsAssignid INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE (RsAssignChilds.EmpCode = '" + Emp + "') AND (RsAssignChilds.Comid = '" + Session["Comid"] + "') AND (RsAssigns.Comid = '" + Session["Comid"] + "') AND (Shiftes.Comid = '" + Session["Comid"] + "') ORDER BY RsAssignChilds.RsAssignid DESC").SingleOrDefault();
            _context.Database.ExecuteSqlCommand("DELETE FROM EmployeeAttendanceReports WHERE (EmpCode = '" + Userid + "' AND (Calenderid = '" + Calender + "') )");
            var Calenders = _context.PayRollCalender.SingleOrDefault(c => c.id == Calender);
            var Roaster = _context.Database.SqlQuery<int>("SELECT Roasterid FROM Employees WHERE (EmpCode = '" + Emp + "')").SingleOrDefault();
            //var Employees = _context.Database.SqlQuery<int>("SELECT * FROM Employees WHERE (EmpCode = "+ Emp +")").ToList();
            var Stdate = Calenders.StDate;
            var Endate = Calenders.EnDate;
            //int A = 0;
            //int B = 0;
            int ShiftHours = 0, OT = 0; 
            DateTime StTime = Convert.ToDateTime("1900-01-01 00:00:00"),
                EnTime = Convert.ToDateTime("1900-01-01 00:00:00"),
                dbEarlyStTimeinMin = Convert.ToDateTime("1900-01-01 00:00:00"),
                dbLateStTimeinMin = Convert.ToDateTime("1900-01-01 00:00:00"),
                dbEarlyEnTimeinMin = Convert.ToDateTime("1900-01-01 00:00:00"),
                dbLateEnTimeinMin = Convert.ToDateTime("1900-01-01 00:00:00"),
                MonthName = Convert.ToDateTime("1900-01-01 00:00:00"),
                FStTime = Convert.ToDateTime("1900-01-01 00:00:00"),
                FEnTime = Convert.ToDateTime("1900-01-01 00:00:00")
                ;
            string EarlyStTimeinMin = "0", EarlyEnTimeinMin = "0", LateStTimeinMin = "0", LateEnTimeinMin = "0", CheckIn = "", Checkout = "", Final = "";
            List<DateTime> li = new List<DateTime>();
            DateTime stdt = Convert.ToDateTime(Stdate);
            DateTime endt = Convert.ToDateTime(Endate);
            int TotalDays = endt.Day;
            while (stdt <= endt)
            {
                li.Add(stdt);
                stdt = stdt.AddDays(1);
            }
            
            StTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.StTime FROM RsAssigns INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE(RsAssigns.Shiftid = " + Shiftid + ")").SingleOrDefault();
            EnTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.EnTime FROM RsAssigns INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE(RsAssigns.Shiftid = " + Shiftid + ")").SingleOrDefault();
            EarlyStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyStTimeinMin FROM RsAssigns INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE(RsAssigns.Shiftid = " + Shiftid + ")").SingleOrDefault();
            EarlyEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyEnTimeinMin FROM RsAssigns INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE(RsAssigns.Shiftid = " + Shiftid + ")").SingleOrDefault();
            LateStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateStTimeinMin FROM RsAssigns INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE(RsAssigns.Shiftid = " + Shiftid + ")").SingleOrDefault();
            LateEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateEnTimeinMin FROM RsAssigns INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE(RsAssigns.Shiftid = " + Shiftid + ")").SingleOrDefault();
            ShiftHours = _context.Database.SqlQuery<int>("SELECT TOP(1) Shiftes.ShiftHours FROM RsAssigns INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE(RsAssigns.Shiftid = " + Shiftid + ")").SingleOrDefault();
            for (int i = 0; i < li.Count(); i++)
            {
                MonthName = li[i];        
                string CheckStTime = StTime.ToString("HH:mm:ss tt");
                string CheckEnTime = EnTime.ToString("HH:mm:ss tt");
                DateTime StTime1 = StTime;
                DateTime EnTime1 = EnTime;

                DateTime Sttimes = Convert.ToDateTime(li[i].Date.ToString("yyyy-MM-dd") +" "+ CheckStTime );
                DateTime Entimes = Sttimes.AddHours(ShiftHours);
                FStTime = Sttimes.AddMinutes(- 90);
                if (ShiftHours <= 9)
                {
                    FEnTime = Sttimes.AddHours(20);
                }
                if (ShiftHours ==12 )
                {
                    FEnTime = Sttimes.AddHours(18);
                }

                string sqlsr;
                sqlsr = "SELECT TOP(1) CHECKTIME FROM CHECKINOUT WHERE (USERID = '" + Userid + "') AND (CHECKTIME BETWEEN '" + Sttimes + "' AND '" + Entimes + "')  ORDER BY CHECKTIME";
                var StTimedb = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) CHECKTIME FROM CHECKINOUT WHERE (USERID = '" + Userid + "') AND (CHECKTIME BETWEEN '" + FStTime + "' AND '" + FEnTime +"')  ORDER BY CHECKTIME").SingleOrDefault();
                var EnTimedb = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) CHECKTIME FROM CHECKINOUT WHERE (USERID = '" + Userid + "') AND (CHECKTIME BETWEEN '" + FStTime + "' AND '" + FEnTime + "')  ORDER BY CHECKTIME DESC").SingleOrDefault();
                //overtime in mins
                if ((StTimedb.Year.ToString() !="1" || EnTimedb.Year.ToString() != "1") && (StTimedb != EnTimedb) )
                {
                    DateTime dtFrom = DateTime.Parse("" + StTimedb.ToString("HH:mm tt") + "");
                    DateTime dtTo = DateTime.Parse("" + EnTimedb.ToString("HH:mm tt") + "");
                    int timeDiff = dtFrom.Subtract(dtTo).Minutes;
                    int shiftinmins = ShiftHours * 60;
                     OT = shiftinmins - timeDiff;
                }
                else
                {
                    OT = 0;
                }
                

                if (StTimedb.Year.ToString() != "1")
                {
                    DateTime DtSt = StTime.AddMinutes(Convert.ToInt32(EarlyStTimeinMin) * -1);
                    dbEarlyStTimeinMin = Convert.ToDateTime("" + li[i].Date.ToString("yyyy-MM-dd") + " " + DtSt.ToString("HH:mm:ss tt") + "");
                    DateTime DtSt1 = StTime1.AddMinutes(Convert.ToInt32(LateStTimeinMin) * 1);
                    dbLateStTimeinMin= Convert.ToDateTime("" + li[i].Date.ToString("yyyy-MM-dd") + " " + DtSt1.ToString("HH:mm:ss tt") + ""); 
                }

                if (EnTimedb.Year.ToString() != "1")
                {
                    FEnTime = FEnTime.AddHours(-12);
                    DateTime DtEn = EnTime.AddMinutes(Convert.ToInt32(EarlyEnTimeinMin) * -1);
                    dbEarlyEnTimeinMin = Convert.ToDateTime(""+ FEnTime.ToString("yyyy-MM-dd") +" "+ DtEn.ToString("HH:mm:ss tt") + "");
                    DateTime DtEn1 = EnTime1.AddMinutes(Convert.ToInt32(LateEnTimeinMin) * 1);
                    dbLateEnTimeinMin = Convert.ToDateTime("" + FEnTime.ToString("yyyy-MM-dd") + " " + DtEn1.ToString("HH:mm:ss tt") + "");
                }

                // _context.Database.SqlQuery<int>("SELECT COUNT(*) AS Expr1 FROM CHECKINOUT WHERE(CHECKTIME BETWEEN '"+ li[i].Date.ToString("yyyy-MM-dd") +" "+ dbEarlyStTimeinMin.ToString("HH:mm:ss tt") + "' AND '" + li[i].Date.ToString("yyyy-MM-dd") + " "+ dbLateStTimeinMin.ToString("HH:mm:ss tt") + "')").SingleOrDefault();

                //Check in status conditions
                if (StTimedb.Year.ToString() != "1")
                {
                    if(StTimedb< dbLateStTimeinMin)
                    {
                        CheckIn = "On Time";
                    }
                    else
                    {
                        CheckIn = "Late";
                    }
                }
                else
                {
                    CheckIn = "Time In Missing";
                }

                //Check out status conditions
                if (EnTimedb.Year.ToString() != "1")
                {
                    if (EnTimedb < dbLateEnTimeinMin)
                    {
                        Checkout = "On Time";
                    }
                    else
                    {
                        Checkout = "Late";
                    }
                }
                else
                {
                    Checkout = "Time Out Missing";
                }

                if (StTimedb.Year.ToString() != "1" && EnTimedb.Year.ToString() != "1")
                {
                    Final = "Present";
                }
                //if (StTimedb.Year.ToString() != "1" && EnTimedb.Year.ToString() != "1" || Checkout == "Late" || CheckIn == "Late")
                if (Checkout == "Late" || CheckIn == "Late")
                {
                    Final = "Late";
                }
                if (StTimedb == EnTimedb)
                {
                    Final = "Absent";
                }
                if (StTimedb.Year.ToString() == "1" || EnTimedb.Year.ToString() == "1" && li[i].DayOfWeek.ToString() != RestDay)
                {
                    Final = "Absent";
                }
                if (li[i].DayOfWeek.ToString() == RestDay)
                {
                    Final = "RestDay";
                }

                _context.Database.ExecuteSqlCommand("INSERT INTO EmployeeAttendanceReports(Date, DateName, DateTimeIn, DateTimeout, CheckIn, CheckOut, Final,EmpCode,Calenderid,OverTime) VALUES " +
                    "('" + li[i].Date.ToString("yyyy-MM-dd") + "','" + li[i].DayOfWeek.ToString() + "','" + StTimedb + "','" + EnTimedb + "','" + CheckIn + "','" + Checkout + "','" + Final + "','" + Userid + "','" + Calender + "','"+ OT +"') ");
            }
            var ERVMQ = _context.Database.SqlQuery<ERVMQ>("SELECT Employees.EmpCode, Employees.Name, Employees.Cnic, Employees.JoiningDate, Branches.Name AS BranchName, Departmentes.Name AS DepartmentName, Designations.Name AS DesignationName, Employees.offDay FROM Employees INNER JOIN Branches ON Employees.Branchid = Branches.id INNER JOIN Departmentes ON Employees.Departid = Departmentes.id INNER JOIN Designations ON Employees.Designationid = Designations.id WHERE(Employees.EmpCode = '" + Emp + "')").SingleOrDefault();
            var EmployeeAttendanceReportList = _context.EmployeeAttendanceReport.SqlQuery("SELECT * FROM EmployeeAttendanceReports WHERE(EmpCode = '" + Userid + "') AND (Calenderid = " + Calender + ")").ToList();
            var PresentDays = _context.Database.SqlQuery<int>("SELECT COUNT(*) AS PresentDays FROM EmployeeAttendanceReports WHERE(EmpCode = '" + Userid + "') AND (Calenderid = '" + Calender + "') AND (Final = 'Present')").SingleOrDefault();
            var AbsentDays = _context.Database.SqlQuery<int>("SELECT COUNT(*) AS PresentDays FROM EmployeeAttendanceReports WHERE(EmpCode = '" + Userid + "') AND (Calenderid = '" + Calender + "') AND (Final = 'Absent')").SingleOrDefault();
            var RestDays = _context.Database.SqlQuery<int>("SELECT COUNT(*) AS PresentDays FROM EmployeeAttendanceReports WHERE(EmpCode = '" + Userid + "') AND (Calenderid = '" + Calender + "') AND (Final = 'RestDay')").SingleOrDefault();
            var Late = _context.Database.SqlQuery<int>("SELECT COUNT(*) AS PresentDays FROM EmployeeAttendanceReports WHERE(EmpCode = '" + Userid + "') AND (Calenderid = '" + Calender + "') AND (Final = 'Late')").SingleOrDefault();
            var OffDay = _context.Database.SqlQuery<string>("SELECT TOP(1) LeaveDay FROM RsAssignChilds WHERE (EmpCode = '" + Emp + "') AND (Comid = '" + Session["Comid"] + "') ORDER BY RsAssignid DESC").SingleOrDefault();
            var ShiftName = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.Name FROM RsAssignChilds INNER JOIN RsAssigns ON RsAssignChilds.RsAssignid = RsAssigns.RsAssignid INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE (RsAssignChilds.EmpCode = '" + Emp + "') AND (RsAssignChilds.Comid = '" + Session["Comid"] + "') AND (RsAssigns.Comid = '" + Session["Comid"] + "') AND (Shiftes.Comid = '" + Session["Comid"] + "') ORDER BY RsAssignChilds.RsAssignid DESC").SingleOrDefault();
            var StartTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.StTime FROM RsAssignChilds INNER JOIN RsAssigns ON RsAssignChilds.RsAssignid = RsAssigns.RsAssignid INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE (RsAssignChilds.EmpCode = '" + Emp + "') AND (RsAssignChilds.Comid = '" + Session["Comid"] + "') AND (RsAssigns.Comid = '" + Session["Comid"] + "') AND (Shiftes.Comid = '" + Session["Comid"] + "') ORDER BY RsAssignChilds.RsAssignid DESC").SingleOrDefault();
            var EndTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.EnTime FROM RsAssignChilds INNER JOIN RsAssigns ON RsAssignChilds.RsAssignid = RsAssigns.RsAssignid INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE (RsAssignChilds.EmpCode = '" + Emp + "') AND (RsAssignChilds.Comid = '" + Session["Comid"] + "') AND (RsAssigns.Comid = '" + Session["Comid"] + "') AND (Shiftes.Comid = '" + Session["Comid"] + "') ORDER BY RsAssignChilds.RsAssignid DESC").SingleOrDefault();
            var EmployeeReportVM = new EmployeeReportVM
            {
                ERVMQ = ERVMQ,
                EmployeeAttendanceReportList = EmployeeAttendanceReportList,
                PresentDays = PresentDays,
                AbsentDays = AbsentDays,
                RestDays = RestDays,
                OffDays = OffDay,
                ShiftName = ShiftName,
                MonthName = MonthName,
                StartTime = StartTime,
                EndTime = EndTime,
                TotalDays= TotalDays,
                Late=Late,
            };
            return View(EmployeeReportVM);
        }
        public ActionResult Daily()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DailyReport(string Dt)
        {
            var Check = _context.Database.SqlQuery<int>("SELECT COUNT(*) AS Expr1 FROM EmployeeAttendanceReports WHERE(Date = '"+ Dt +"')").SingleOrDefault();
            if (Check <= 0)
            {
                DateTime DayOfWeek = Convert.ToDateTime(Dt);
                List<string> Emp = new List<string>();
                Emp = _context.Database.SqlQuery<string>("SELECT EmpCode FROM Employees WHERE (comid = '" + Session["Comid"] + "') AND (EmployeeStatus = 'Active')").ToList();
                int ShiftHours = 0, OT = 0;
                DateTime StTime = Convert.ToDateTime("1900-01-01 00:00:00"),
                EnTime = Convert.ToDateTime("1900-01-01 00:00:00"),
                dbEarlyStTimeinMin = Convert.ToDateTime("1900-01-01 00:00:00"),
                dbLateStTimeinMin = Convert.ToDateTime("1900-01-01 00:00:00"),
                dbEarlyEnTimeinMin = Convert.ToDateTime("1900-01-01 00:00:00"),
                dbLateEnTimeinMin = Convert.ToDateTime("1900-01-01 00:00:00"),
                MonthName = Convert.ToDateTime("1900-01-01 00:00:00"),
                FStTime = Convert.ToDateTime("1900-01-01 00:00:00"),
                FEnTime = Convert.ToDateTime("1900-01-01 00:00:00")
                ;
                string EarlyStTimeinMin = "0", EarlyEnTimeinMin = "0", LateStTimeinMin = "0", LateEnTimeinMin = "0", CheckIn = "", Checkout = "", Final = "", ShiftName="";
                for (int i = 0; i < Emp.Count(); i++)
                {
                    //Data

                    var Userid = _context.Database.SqlQuery<int>("SELECT USERINFO.USERID FROM USERINFO INNER JOIN Employees ON USERINFO.NAME = Employees.EmpCode WHERE(USERINFO.NAME = '" + Emp[i] + "')").SingleOrDefault();
                    var RestDay = _context.Database.SqlQuery<string>("SELECT offDay FROM Employees WHERE(EmployeeStatus = 'Active') AND (comid = '"+ Session["Comid"] + "') AND (EmpCode = '" + Emp[i] + "')").SingleOrDefault();
                    int Roaster = _context.Database.SqlQuery<int>("SELECT Roasterid FROM Employees WHERE(EmployeeStatus = 'Active') AND (comid = '" + Session["Comid"] + "') AND (EmpCode = '"+ Emp[i] +"')").SingleOrDefault();
                    switch (DayOfWeek.DayOfWeek.ToString())
                    {
                        case "Monday":
                            StTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.StTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Monday')").SingleOrDefault();
                            EnTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.EnTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Monday')").SingleOrDefault();
                            EarlyStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Monday')").SingleOrDefault();
                            EarlyEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Monday')").SingleOrDefault();
                            LateStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Monday')").SingleOrDefault();
                            LateEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Monday')").SingleOrDefault();
                            ShiftHours = _context.Database.SqlQuery<int>("SELECT TOP(1) Shiftes.ShiftHours FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Monday')").SingleOrDefault();
                            ShiftName = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.Name FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Monday')").SingleOrDefault();
                            break;
                        case "Tuesday":
                            StTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.StTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Tuesday')").SingleOrDefault();
                            EnTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.EnTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Tuesday')").SingleOrDefault();
                            EarlyStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Tuesday')").SingleOrDefault();
                            EarlyEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Tuesday')").SingleOrDefault();
                            LateStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Tuesday')").SingleOrDefault();
                            LateEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Tuesday')").SingleOrDefault();
                            ShiftHours = _context.Database.SqlQuery<int>("SELECT TOP(1) Shiftes.ShiftHours FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Tuesday')").SingleOrDefault();
                            ShiftName = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.Name FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Tuesday')").SingleOrDefault();
                            break;
                        case "Wednesday":
                            StTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.StTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Wednesday')").SingleOrDefault();
                            EnTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.EnTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Wednesday')").SingleOrDefault();
                            EarlyStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Wednesday')").SingleOrDefault();
                            EarlyEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Wednesday')").SingleOrDefault();
                            LateStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Wednesday')").SingleOrDefault();
                            LateEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Wednesday')").SingleOrDefault();
                            ShiftHours = _context.Database.SqlQuery<int>("SELECT TOP(1) Shiftes.ShiftHours FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Wednesday')").SingleOrDefault();
                            ShiftName = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.Name FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Wednesday')").SingleOrDefault();
                            break;
                        case "Thursday":
                            StTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.StTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Thursday')").SingleOrDefault();
                            EnTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.EnTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Thursday')").SingleOrDefault();
                            EarlyStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Thursday')").SingleOrDefault();
                            EarlyEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Thursday')").SingleOrDefault();
                            LateStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Thursday')").SingleOrDefault();
                            LateEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Thursday')").SingleOrDefault();
                            ShiftHours = _context.Database.SqlQuery<int>("SELECT TOP(1) Shiftes.ShiftHours FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Thursday')").SingleOrDefault();
                            ShiftName = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.Name FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Thursday')").SingleOrDefault();
                            break;
                        case "Friday":
                            StTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.StTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Friday')").SingleOrDefault();
                            EnTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.EnTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Friday')").SingleOrDefault();
                            EarlyStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Friday')").SingleOrDefault();
                            EarlyEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Friday')").SingleOrDefault();
                            LateStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Friday')").SingleOrDefault();
                            LateEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Friday')").SingleOrDefault();
                            ShiftHours = _context.Database.SqlQuery<int>("SELECT TOP(1) Shiftes.ShiftHours FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Friday')").SingleOrDefault();
                            ShiftName = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.Name FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Friday')").SingleOrDefault();
                            break;
                        case "Saturday":
                            StTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.StTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Saturday')").SingleOrDefault();
                            EnTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.EnTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Saturday')").SingleOrDefault();
                            EarlyStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Saturday')").SingleOrDefault();
                            EarlyEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Saturday')").SingleOrDefault();
                            LateStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Saturday')").SingleOrDefault();
                            LateEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Saturday')").SingleOrDefault();
                            ShiftHours = _context.Database.SqlQuery<int>("SELECT TOP(1) Shiftes.ShiftHours FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Saturday')").SingleOrDefault();
                            ShiftName = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.Name FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Saturday')").SingleOrDefault();
                            break;
                        case "Sunday":
                            StTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.StTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Sunday')").SingleOrDefault();
                            EnTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.EnTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Sunday')").SingleOrDefault();
                            EarlyStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Sunday')").SingleOrDefault();
                            EarlyEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Sunday')").SingleOrDefault();
                            LateStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Sunday')").SingleOrDefault();
                            LateEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Sunday')").SingleOrDefault();
                            ShiftHours = _context.Database.SqlQuery<int>("SELECT TOP(1) Shiftes.ShiftHours FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Sunday')").SingleOrDefault();
                            ShiftName = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.Name FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Sunday')").SingleOrDefault();
                            break;
                    }
                    //var Shiftid = _context.Database.SqlQuery<int>("SELECT TOP(1) Shiftes.id FROM RsAssignChilds INNER JOIN RsAssigns ON RsAssignChilds.RsAssignid = RsAssigns.RsAssignid INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE (RsAssignChilds.EmpCode = '" + Emp[i] + "') AND (RsAssignChilds.Comid = '" + Session["Comid"] + "') AND (RsAssigns.Comid = '" + Session["Comid"] + "') AND (Shiftes.Comid = '" + Session["Comid"] + "') ORDER BY RsAssignChilds.RsAssignid DESC").SingleOrDefault();
                    //var ShiftName = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.Name FROM RsAssignChilds INNER JOIN RsAssigns ON RsAssignChilds.RsAssignid = RsAssigns.RsAssignid INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE (RsAssignChilds.EmpCode = '" + Emp[i] + "') AND (RsAssignChilds.Comid = '" + Session["Comid"] + "') AND (RsAssigns.Comid = '" + Session["Comid"] + "') AND (Shiftes.Comid = '" + Session["Comid"] + "') ORDER BY RsAssignChilds.RsAssignid DESC").SingleOrDefault();
                    //GetData
                    //StTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.StTime FROM RsAssigns INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE(RsAssigns.Shiftid = " + Shiftid + ")").SingleOrDefault();
                    //EnTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.EnTime FROM RsAssigns INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE(RsAssigns.Shiftid = " + Shiftid + ")").SingleOrDefault();
                    //EarlyStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyStTimeinMin FROM RsAssigns INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE(RsAssigns.Shiftid = " + Shiftid + ")").SingleOrDefault();
                    //EarlyEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyEnTimeinMin FROM RsAssigns INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE(RsAssigns.Shiftid = " + Shiftid + ")").SingleOrDefault();
                    //LateStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateStTimeinMin FROM RsAssigns INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE(RsAssigns.Shiftid = " + Shiftid + ")").SingleOrDefault();
                    //LateEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateEnTimeinMin FROM RsAssigns INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE(RsAssigns.Shiftid = " + Shiftid + ")").SingleOrDefault();
                    //ShiftHours = _context.Database.SqlQuery<int>("SELECT TOP(1) Shiftes.ShiftHours FROM RsAssigns INNER JOIN Shiftes ON RsAssigns.Shiftid = Shiftes.id WHERE(RsAssigns.Shiftid = " + Shiftid + ")").SingleOrDefault();

                    //Report
                    string CheckStTime = StTime.ToString("HH:mm:ss tt");
                    string CheckEnTime = EnTime.ToString("HH:mm:ss tt");
                    DateTime StTime1 = StTime;
                    DateTime EnTime1 = EnTime;

                    DateTime Sttimes = Convert.ToDateTime(Dt + " " + CheckStTime);
                    DateTime Entimes = Sttimes.AddHours(ShiftHours);
                    FStTime = Sttimes.AddMinutes(-90);
                    if (ShiftHours <= 9)
                    {
                        FEnTime = Sttimes.AddHours(20);
                    }
                    if (ShiftHours == 12)
                    {
                        FEnTime = Sttimes.AddHours(18);
                    }

                    //Get From Database
                    var StTimedb = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) CHECKTIME FROM CHECKINOUT WHERE (USERID = '" + Userid + "') AND (CHECKTIME BETWEEN '" + FStTime + "' AND '" + FEnTime + "')  ORDER BY CHECKTIME").SingleOrDefault();
                    var EnTimedb = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) CHECKTIME FROM CHECKINOUT WHERE (USERID = '" + Userid + "') AND (CHECKTIME BETWEEN '" + FStTime + "' AND '" + FEnTime + "')  ORDER BY CHECKTIME DESC").SingleOrDefault();
                    //overtime in mins
                    if ((StTimedb.Year.ToString() != "1" || EnTimedb.Year.ToString() != "1") && (StTimedb != EnTimedb))
                    {
                        DateTime dtFrom = DateTime.Parse("" + StTimedb.ToString("HH:mm tt") + "");
                        DateTime dtTo = DateTime.Parse("" + EnTimedb.ToString("HH:mm tt") + "");
                        int timeDiff = dtTo.Subtract(dtFrom).Minutes;
                        int shiftinmins = ShiftHours * 60;
                        OT = shiftinmins - timeDiff;
                    }
                    else
                    {
                        OT = 0;
                    }

                    if (StTimedb.Year.ToString() != "1")
                    {
                        DateTime DtSt = StTime.AddMinutes(Convert.ToInt32(EarlyStTimeinMin) * -1);
                        dbEarlyStTimeinMin = Convert.ToDateTime("" + Dt + " " + DtSt.ToString("HH:mm:ss tt") + "");
                        DateTime DtSt1 = StTime1.AddMinutes(Convert.ToInt32(LateStTimeinMin) * 1);
                        dbLateStTimeinMin = Convert.ToDateTime("" + Dt + " " + DtSt1.ToString("HH:mm:ss tt") + "");
                    }

                    if (EnTimedb.Year.ToString() != "1")
                    {
                        FEnTime = FEnTime.AddHours(-12);
                        DateTime DtEn = EnTime.AddMinutes(Convert.ToInt32(EarlyEnTimeinMin) * -1);
                        dbEarlyEnTimeinMin = Convert.ToDateTime("" + FEnTime.ToString("yyyy-MM-dd") + " " + DtEn.ToString("HH:mm:ss tt") + "");
                        DateTime DtEn1 = EnTime1.AddMinutes(Convert.ToInt32(LateEnTimeinMin) * 1);
                        dbLateEnTimeinMin = Convert.ToDateTime("" + FEnTime.ToString("yyyy-MM-dd") + " " + DtEn1.ToString("HH:mm:ss tt") + "");
                    }

                    //Check in status conditions
                    if (StTimedb.Year.ToString() != "1")
                    {
                        if (StTimedb < dbLateStTimeinMin)
                        {
                            CheckIn = "On Time";
                        }
                        else
                        {
                            CheckIn = "Late";
                        }
                    }
                    else
                    {
                        CheckIn = "Time In Missing";
                    }

                    //Check out status conditions
                    if (EnTimedb.Year.ToString() != "1")
                    {
                        if (EnTimedb < dbLateEnTimeinMin)
                        {
                            Checkout = "On Time";
                        }
                        else
                        {
                            Checkout = "Late";
                        }
                    }
                    else
                    {
                        Checkout = "Time Out Missing";
                    }

                    if (StTimedb.Year.ToString() != "1" && EnTimedb.Year.ToString() != "1")
                    {
                        Final = "Present";
                    }

                    if (Checkout == "Late" || CheckIn == "Late")
                    {
                        Final = "Late";
                    }
                    if (StTimedb == EnTimedb)
                    {
                        Final = "Absent";
                    }
                    if (StTimedb.Year.ToString() == "1" || EnTimedb.Year.ToString() == "1" && DayOfWeek.DayOfWeek.ToString() != RestDay)
                    {
                        Final = "Absent";
                    }
                    if (DayOfWeek.DayOfWeek.ToString() == RestDay)
                    {
                        Final = "RestDay";
                    }
                    //Query
                    _context.Database.ExecuteSqlCommand("INSERT INTO EmployeeAttendanceReports(Date, DateName, DateTimeIn, DateTimeout, CheckIn, CheckOut, Final,EmpCode,Calenderid,OverTime,ShiftName,ShiftStartTime,ShiftEndTime) VALUES " +
                        "('" + Dt + "','" + DayOfWeek.DayOfWeek.ToString() + "','" + StTimedb + "','" + EnTimedb + "','" + CheckIn + "','" + Checkout + "','" + Final + "','" + Userid + "','0','" + OT + "','"+ ShiftName + "','"+ StTime + "','"+ EnTime + "') ");
                }
                var DailyReport = _context.Database.SqlQuery<EmployeeDailyReportVMQ>("SELECT EmployeeAttendanceReports.id, EmployeeAttendanceReports.Date, EmployeeAttendanceReports.DateName, EmployeeAttendanceReports.DateTimeIn, EmployeeAttendanceReports.DateTimeout, EmployeeAttendanceReports.CheckIn, EmployeeAttendanceReports.CheckOut, EmployeeAttendanceReports.Final, EmployeeAttendanceReports.OverTime, Employees.Name, EmployeeAttendanceReports.EmpCode, EmployeeAttendanceReports.ShiftName, EmployeeAttendanceReports.ShiftStartTime, EmployeeAttendanceReports.ShiftEndTime FROM EmployeeAttendanceReports INNER JOIN USERINFO ON EmployeeAttendanceReports.EmpCode = USERINFO.USERID INNER JOIN Employees ON USERINFO.NAME = Employees.EmpCode WHERE(EmployeeAttendanceReports.Date = '"+ Dt +"') GROUP BY EmployeeAttendanceReports.id, EmployeeAttendanceReports.Date, EmployeeAttendanceReports.DateName, EmployeeAttendanceReports.DateTimeIn, EmployeeAttendanceReports.DateTimeout, EmployeeAttendanceReports.CheckIn, EmployeeAttendanceReports.CheckOut, EmployeeAttendanceReports.Final, EmployeeAttendanceReports.OverTime, Employees.Name, EmployeeAttendanceReports.EmpCode, EmployeeAttendanceReports.ShiftName, EmployeeAttendanceReports.ShiftStartTime, EmployeeAttendanceReports.ShiftEndTime").ToList();
                var VM = new DailyReportVM
                {
                    EmployeeDailyReportVMQList = DailyReport,
                    DateName = Dt
                };
                return View(VM);
            }
            else
            {
                var DailyReport = _context.Database.SqlQuery<EmployeeDailyReportVMQ>("SELECT EmployeeAttendanceReports.id, EmployeeAttendanceReports.Date, EmployeeAttendanceReports.DateName, EmployeeAttendanceReports.DateTimeIn, EmployeeAttendanceReports.DateTimeout, EmployeeAttendanceReports.CheckIn, EmployeeAttendanceReports.CheckOut, EmployeeAttendanceReports.Final, EmployeeAttendanceReports.OverTime, Employees.Name, EmployeeAttendanceReports.EmpCode, EmployeeAttendanceReports.ShiftName, EmployeeAttendanceReports.ShiftStartTime, EmployeeAttendanceReports.ShiftEndTime FROM EmployeeAttendanceReports INNER JOIN USERINFO ON EmployeeAttendanceReports.EmpCode = USERINFO.USERID INNER JOIN Employees ON USERINFO.NAME = Employees.EmpCode WHERE(EmployeeAttendanceReports.Date = '" + Dt + "') GROUP BY EmployeeAttendanceReports.id, EmployeeAttendanceReports.Date, EmployeeAttendanceReports.DateName, EmployeeAttendanceReports.DateTimeIn, EmployeeAttendanceReports.DateTimeout, EmployeeAttendanceReports.CheckIn, EmployeeAttendanceReports.CheckOut, EmployeeAttendanceReports.Final, EmployeeAttendanceReports.OverTime, Employees.Name, EmployeeAttendanceReports.EmpCode, EmployeeAttendanceReports.ShiftName, EmployeeAttendanceReports.ShiftStartTime, EmployeeAttendanceReports.ShiftEndTime").ToList();
                var VM = new DailyReportVM
                {
                    EmployeeDailyReportVMQList = DailyReport,
                    DateName = Dt
                };
                return View(VM);
            }
        }

        //public ActionResult Search(int Calender, string Emp)
        //{
        //    var Userid = _context.Database.SqlQuery<int>("SELECT USERINFO.USERID FROM USERINFO INNER JOIN Employees ON USERINFO.NAME = Employees.EmpCode WHERE(USERINFO.NAME = '" + Emp + "')").SingleOrDefault();
        //    var RestDay = _context.Database.SqlQuery<string>("SELECT LeaveDay FROM RsAssignChilds WHERE (EmpCode = '" + Emp + "')").SingleOrDefault();
        //    _context.Database.ExecuteSqlCommand("DELETE FROM EmployeeAttendanceReports WHERE (EmpCode = '" + Userid + "' AND (Calenderid = '" + Calender + "') )");
        //    var Calenders = _context.PayRollCalender.SingleOrDefault(c => c.id == Calender);
        //    var Roaster = _context.Database.SqlQuery<int>("SELECT Roasterid FROM Employees WHERE (EmpCode = '" + Emp + "')").SingleOrDefault();
        //    //var Employees = _context.Database.SqlQuery<int>("SELECT * FROM Employees WHERE (EmpCode = "+ Emp +")").ToList();
        //    var Stdate = Calenders.StDate;
        //    var Endate = Calenders.EnDate;
        //    //int A = 0;
        //    //int B = 0;
        //    DateTime StTime = Convert.ToDateTime("1900-01-01 00:00:00"),
        //        EnTime = Convert.ToDateTime("1900-01-01 00:00:00"),
        //        dbEarlyStTimeinMin = Convert.ToDateTime("1900-01-01 00:00:00"),
        //        dbLateStTimeinMin = Convert.ToDateTime("1900-01-01 00:00:00"),
        //        dbEarlyEnTimeinMin = Convert.ToDateTime("1900-01-01 00:00:00"),
        //        dbLateEnTimeinMin = Convert.ToDateTime("1900-01-01 00:00:00")
        //        ;
        //    string EarlyStTimeinMin = "0", EarlyEnTimeinMin = "0", LateStTimeinMin = "0", LateEnTimeinMin = "0", CheckIn = "", Checkout = "", Final = "";
        //    List<DateTime> li = new List<DateTime>();

        //    DateTime stdt = Convert.ToDateTime(Stdate);
        //    DateTime endt = Convert.ToDateTime(Endate);
        //    while (stdt <= endt)
        //    {
        //        li.Add(stdt);
        //        stdt = stdt.AddDays(1);
        //    }

        //    for (int i = 0; i < li.Count(); i++)
        //    {
        //        switch (li[i].DayOfWeek.ToString())
        //        {
        //            case "Monday":
        //                StTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.StTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Monday')").SingleOrDefault();
        //                EnTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.EnTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Monday')").SingleOrDefault();
        //                EarlyStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Monday')").SingleOrDefault();
        //                EarlyEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Monday')").SingleOrDefault();
        //                LateStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Monday')").SingleOrDefault();
        //                LateEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Monday')").SingleOrDefault();
        //                break;
        //            case "Tuesday":
        //                StTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.StTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Tuesday')").SingleOrDefault();
        //                EnTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.EnTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Tuesday')").SingleOrDefault();
        //                EarlyStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Tuesday')").SingleOrDefault();
        //                EarlyEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Tuesday')").SingleOrDefault();
        //                LateStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Tuesday')").SingleOrDefault();
        //                LateEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Tuesday')").SingleOrDefault();
        //                break;
        //            case "Wednesday":
        //                StTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.StTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Wednesday')").SingleOrDefault();
        //                EnTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.EnTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Wednesday')").SingleOrDefault();
        //                EarlyStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Wednesday')").SingleOrDefault();
        //                EarlyEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Wednesday')").SingleOrDefault();
        //                LateStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Wednesday')").SingleOrDefault();
        //                LateEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Wednesday')").SingleOrDefault();
        //                break;
        //            case "Thursday":
        //                StTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.StTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Thursday')").SingleOrDefault();
        //                EnTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.EnTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Thursday')").SingleOrDefault();
        //                EarlyStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Thursday')").SingleOrDefault();
        //                EarlyEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Thursday')").SingleOrDefault();
        //                LateStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Thursday')").SingleOrDefault();
        //                LateEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Thursday')").SingleOrDefault();
        //                break;
        //            case "Friday":
        //                StTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.StTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Friday')").SingleOrDefault();
        //                EnTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.EnTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Friday')").SingleOrDefault();
        //                EarlyStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Friday')").SingleOrDefault();
        //                EarlyEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Friday')").SingleOrDefault();
        //                LateStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Friday')").SingleOrDefault();
        //                LateEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Friday')").SingleOrDefault();
        //                break;
        //            case "Saturday":
        //                StTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.StTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Saturday')").SingleOrDefault();
        //                EnTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.EnTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Saturday')").SingleOrDefault();
        //                EarlyStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Saturday')").SingleOrDefault();
        //                EarlyEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Saturday')").SingleOrDefault();
        //                LateStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Saturday')").SingleOrDefault();
        //                LateEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Saturday')").SingleOrDefault();
        //                break;
        //            case "Sunday":
        //                StTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.StTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Sunday')").SingleOrDefault();
        //                EnTime = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) Shiftes.EnTime FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Sunday')").SingleOrDefault();
        //                EarlyStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Sunday')").SingleOrDefault();
        //                EarlyEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.EarlyEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Sunday')").SingleOrDefault();
        //                LateStTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateStTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Sunday')").SingleOrDefault();
        //                LateEnTimeinMin = _context.Database.SqlQuery<string>("SELECT TOP(1) Shiftes.LateEnTimeinMin FROM AssignRoasters INNER JOIN Shiftes ON AssignRoasters.Shiftid = Shiftes.id WHERE (AssignRoasters.Roasterid = '" + Roaster + "') AND (AssignRoasters.Day = 'Sunday')").SingleOrDefault();
        //                break;
        //        }
        //        string CheckStTime = StTime.ToString("HH:mm:ss tt");
        //        string CheckEnTime = EnTime.ToString("HH:mm:ss tt");

        //        //string sqlsr;
        //        //sqlsr = "SELECT TOP(1) Datetime FROM EmployeeAttendances WHERE (EmpCode = '" + Emp + "') AND (Datetime BETWEEN '" + li[i].Date.ToString("yyyy-MM-dd") + " " + CheckStTime + "' AND '" + li[i].Date.ToString("yyyy-MM-dd") + " " + CheckEnTime + "') AND (Status = 1) ORDER BY Datetime";
        //        var StTimedb = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) CHECKTIME FROM CHECKINOUT WHERE (USERID = '" + Userid + "') AND (CHECKTIME BETWEEN '" + li[i].Date.ToString("yyyy-MM-dd") + " " + CheckStTime + "' AND '" + li[i].Date.ToString("yyyy-MM-dd") + " " + CheckEnTime + "')  ORDER BY CHECKTIME").SingleOrDefault();
        //        var EnTimedb = _context.Database.SqlQuery<DateTime>("SELECT TOP(1) CHECKTIME FROM CHECKINOUT WHERE (USERID = '" + Userid + "') AND (CHECKTIME BETWEEN '" + li[i].Date.ToString("yyyy-MM-dd") + " " + CheckStTime + "' AND '" + li[i].Date.ToString("yyyy-MM-dd") + " " + CheckEnTime + "')  ORDER BY CHECKTIME DESC").SingleOrDefault();


        //        if (StTimedb.Year.ToString() != "1")
        //        {
        //            dbEarlyStTimeinMin = StTimedb.AddMinutes(Convert.ToInt32(EarlyStTimeinMin) * -1);
        //            dbLateStTimeinMin = StTimedb.AddMinutes(Convert.ToInt32(LateStTimeinMin) * -1);
        //        }

        //        if (EnTimedb.Year.ToString() != "1")
        //        {
        //            dbEarlyEnTimeinMin = EnTimedb.AddMinutes(Convert.ToInt32(EarlyEnTimeinMin) * -1);
        //            dbLateEnTimeinMin = StTimedb.AddMinutes(Convert.ToInt32(LateEnTimeinMin) * -1);
        //        }

        //        // _context.Database.SqlQuery<int>("SELECT COUNT(*) AS Expr1 FROM CHECKINOUT WHERE(CHECKTIME BETWEEN '"+ li[i].Date.ToString("yyyy-MM-dd") +" "+ dbEarlyStTimeinMin.ToString("HH:mm:ss tt") + "' AND '" + li[i].Date.ToString("yyyy-MM-dd") + " "+ dbLateStTimeinMin.ToString("HH:mm:ss tt") + "')").SingleOrDefault();

        //        //Check in status conditions
        //        if (StTimedb.Year.ToString() != "1")
        //        {

        //            if (_context.Database.SqlQuery<int>("SELECT COUNT(*) AS Expr1 FROM CHECKINOUT WHERE(CHECKTIME BETWEEN '" + li[i].Date.ToString("yyyy-MM-dd") + " " + dbEarlyStTimeinMin.ToString("HH:mm:ss tt") + "' AND '" + li[i].Date.ToString("yyyy-MM-dd") + " " + CheckStTime + "')").SingleOrDefault() > 0)
        //            {
        //                CheckIn = "On Time";
        //            }
        //            if (_context.Database.SqlQuery<int>("SELECT COUNT(*) AS Expr1 FROM CHECKINOUT WHERE(CHECKTIME BETWEEN '" + li[i].Date.ToString("yyyy-MM-dd") + " " + CheckStTime + "' AND '" + li[i].Date.ToString("yyyy-MM-dd") + " " + dbLateStTimeinMin.ToString("HH:mm:ss tt") + "')").SingleOrDefault() > 0)
        //            {
        //                CheckIn = "Late";
        //            }
        //        }
        //        else
        //        {
        //            CheckIn = "Time In Missing";
        //        }

        //        //Check out status conditions
        //        if (EnTimedb.Year.ToString() != "1")
        //        {
        //            if (_context.Database.SqlQuery<int>("SELECT COUNT(*) AS Expr1 FROM CHECKINOUT WHERE(CHECKTIME BETWEEN '" + li[i].Date.ToString("yyyy-MM-dd") + " " + dbEarlyEnTimeinMin.ToString("HH:mm:ss tt") + "' AND '" + li[i].Date.ToString("yyyy-MM-dd") + " " + CheckEnTime + "')").SingleOrDefault() > 0)
        //            {
        //                Checkout = "On Time";
        //            }
        //            if (_context.Database.SqlQuery<int>("SELECT COUNT(*) AS Expr1 FROM CHECKINOUT WHERE(CHECKTIME BETWEEN '" + li[i].Date.ToString("yyyy-MM-dd") + " " + CheckEnTime + "' AND '" + li[i].Date.ToString("yyyy-MM-dd") + " " + dbLateEnTimeinMin.ToString("HH:mm:ss tt") + "')").SingleOrDefault() > 0)
        //            {
        //                Checkout = "Late";
        //            }
        //        }
        //        else
        //        {
        //            Checkout = "Time Out Missing";
        //        }
        //        if (StTimedb.Year.ToString() != "1" && EnTimedb.Year.ToString() != "1")
        //        {
        //            Final = "Present";
        //        }
        //        else if (StTimedb.Year.ToString() != "1" && EnTimedb.Year.ToString() != "1" && li[i].DayOfWeek.ToString() == RestDay)
        //        {
        //            Final = "RestDay";
        //        }
        //        else
        //        {
        //            Final = "Absent";
        //        }



        //        _context.Database.ExecuteSqlCommand("INSERT INTO EmployeeAttendanceReports(Date, DateName, DateTimeIn, DateTimeout, CheckIn, CheckOut, Final,EmpCode,Calenderid) VALUES " +
        //            "('" + li[i].Date.ToString("yyyy-MM-dd") + "','" + li[i].DayOfWeek.ToString() + "','" + StTimedb + "','" + EnTimedb + "','" + CheckIn + "','" + Checkout + "','" + Final + "','" + Userid + "','" + Calender + "') ");
        //    }
        //    var ERVMQ = _context.Database.SqlQuery<ERVMQ>("SELECT Employees.EmpCode, Employees.Name, Employees.Cnic, Employees.JoiningDate, Branches.Name AS BranchName, Departmentes.Name AS DepartmentName, Designations.Name AS DesignationName, Employees.offDay FROM Employees INNER JOIN Branches ON Employees.Branchid = Branches.id INNER JOIN Departmentes ON Employees.Departid = Departmentes.id INNER JOIN Designations ON Employees.Designationid = Designations.id WHERE(Employees.EmpCode = '" + Emp + "')").SingleOrDefault();
        //    var EmployeeAttendanceReportList = _context.EmployeeAttendanceReport.SqlQuery("SELECT id, Date, DateName, DateTimeIn, DateTimeout, CheckIn, CheckOut, Final, EmpCode, Calenderid FROM EmployeeAttendanceReports WHERE(EmpCode = '" + Userid + "') AND (Calenderid = " + Calender + ")").ToList();
        //    var PresentDays = _context.Database.SqlQuery<int>("SELECT COUNT(*) AS PresentDays FROM EmployeeAttendanceReports WHERE(EmpCode = '" + Userid + "') AND (Calenderid = '" + Calender + "') AND (Final = 'Present')").SingleOrDefault();
        //    var AbsentDays = _context.Database.SqlQuery<int>("SELECT COUNT(*) AS PresentDays FROM EmployeeAttendanceReports WHERE(EmpCode = '" + Userid + "') AND (Calenderid = '" + Calender + "') AND (Final = 'Absent')").SingleOrDefault();
        //    var RestDays = _context.Database.SqlQuery<int>("SELECT COUNT(*) AS PresentDays FROM EmployeeAttendanceReports WHERE(EmpCode = '" + Userid + "') AND (Calenderid = '" + Calender + "') AND (Final = 'RestDay')").SingleOrDefault();
        //    var EmployeeReportVM = new EmployeeReportVM
        //    {
        //        ERVMQ = ERVMQ,
        //        EmployeeAttendanceReportList = EmployeeAttendanceReportList,
        //        PresentDays = PresentDays,
        //        AbsentDays = AbsentDays,
        //        RestDays = RestDays,
        //    };
        //    return View(EmployeeReportVM);
        //}

    }
}