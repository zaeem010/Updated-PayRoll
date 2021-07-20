using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PayRoll.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Branch> Branch { get; set; }
        public DbSet<Days> Days { get; set; }
        public DbSet<Departmentes> Departmentes { get; set; }
        public DbSet<Bank> Bank { get; set; }
        public DbSet<Roaster> Roaster { get; set; }
        public DbSet<Shiftes> Shiftes { get; set; }
        public DbSet<SalaryPackage> SalarPackage { get; set; }
        public DbSet<OrgCalender> OrgCalender { get; set; }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<ThirdLevel> ThirdLevel { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<AssignRoaster> AssignRoaster { get; set; }
        public DbSet<OTRequest> OTRequest { get; set; }
        public DbSet<LeaveRequest> LeaveRequest { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendace { get; set; }
        public DbSet<EmployeeAttendanceApproval> EmployeeAttendaceApproval { get; set; }
        public DbSet<Dates> Dates { get; set; }
        public DbSet<PayRollCalender> PayRollCalender { get; set; }
        public DbSet<EmployeeAttendanceReport> EmployeeAttendanceReport { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }
        public DbSet<UserAccess> UserAccess { get; set; }
        public DbSet<RsAssign> RsAssign { get; set; }
        public DbSet<RsAssignChild> RsAssignChild { get; set; }
        public DbSet<RoasterUpdate> RoasterUpdate { get; set; }
        public DbSet<RestdayUpdate> RestdayUpdate { get; set; }
        //public DbSet<AttParam> AttParam { get; set; }
        //public DbSet<CHECKEXACT> CHECKEXACT { get; set; }
        //public DbSet<CHECKINOUT> CHECKINOUT { get; set; }
        //public DbSet<DEPARTMENTS> DEPARTMENTSS { get; set; }
        //public DbSet<EXCNOTES> EXCNOTES { get; set; }
        //public DbSet<HOLIDAYS> HOLIDAYS { get; set; }
        //public DbSet<LeaveClass> LeaveClass { get; set; }
        //public DbSet<LeaveClass1> LeaveClass1 { get; set; }
        //public DbSet<NUM_RUN> NUM_RUN { get; set; }
        //public DbSet<NUM_RUN_DEIL> NUM_RUN_DEIL { get; set; }
        //public DbSet<SchClass> SchClass { get; set; }
        //public DbSet<SECURITYDETAILS> SECURITYDETAILS { get; set; }
        //public DbSet<SHIFT> SHIFT { get; set; }
        //public DbSet<TEMPLATES> TEMPLATE { get; set; }
        //public DbSet<USER_OF_RUN> USER_OF_RUN { get; set; }
        //public DbSet<USER_SPEDAY> USER_SPEDAY { get; set; }
        //public DbSet<USER_TEMP_SCH> USER_TEMP_SCH { get; set; }
        //public DbSet<USERINFO> USERINFO { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}