using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;

namespace PayRoll.Models
{
    public class ZKT
    {
    }
    //public class AttParam
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    //    [StringLength(255)]
    //    public string PARANAME { get; set; }
    //    public string PARATYPE { get; set; }
    //    public string PARAVALUE { get; set; }
    //}
    //public class CHECKEXACT
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int EXACTID { get; set; }
    //    public int USERID { get; set; }
    //    public DateTime CHECKTIME { get; set; }
    //    [StringLength(2)]
    //    public string CHECKTYPE { get; set; }
    //    public int ISADD { get; set; }
    //    [StringLength(25)]
    //    public string YUYIN { get; set; }
    //    public int ISMODIFY { get; set; }
    //    public int ISDELETE { get; set; }
    //    public int INCOUNT { get; set; }
    //    public int ISCOUNT { get; set; }
    //    [StringLength(20)]
    //    public string MODIFYBY { get; set; }
    //    public DateTime DATE { get; set; }
    //}
    //public class CHECKINOUT
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int USERID { get; set; }
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public DateTime CHECKTIME { get; set; }
    //    public string CHECKTYPE { get; set; }
    //    public int VERIFYCODE { get; set; }
    //    public string SENSORID { get; set; }
    //}
    //public class DEPARTMENTS
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int DEPTID { get; set; }
    //    [StringLength(30)]
    //    public string DEPTNAME { get; set; }
    //    public int SUPDEPTID { get; set; }
    //}
    //public class EXCNOTES
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int USERID { get; set; }
    //    public DateTime ATTDATE { get; set; }
    //    [StringLength(200)]
    //    public string NOTES { get; set; }
    //}
    //public class HOLIDAYS
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int HOLIDAYID { get; set; }
    //    public string HOLIDAYNAME { get; set; }
    //    public int HOLIDAYYEAR { get; set; }
    //    public int HOLIDAYMONTH { get; set; }
    //    public DateTime STARTTIME { get; set; }
    //    public int DURATION { get; set; }
    //    public int HOLIDAYTYPE { get; set; }
    //    public string XINBIE { get; set; }
    //    public string MINZU { get; set; }
    //}
    //public class LeaveClass
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int LeaveId { get; set; }
    //    [StringLength(20)]
    //    public string LeaveName { get; set; }
    //    public float MinUnit { get; set; }
    //    public int Unit { get; set; }
    //    public int RemaindProc { get; set; }
    //    public int RemaindCount { get; set; }
    //    [StringLength(4)]
    //    public string ReportSymbol { get; set; }
    //    public float Deduct { get; set; }
    //    public int Color { get; set; }
    //    public int Classify { get; set; }
    //}
    //public class LeaveClass1
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int LeaveId { get; set; }
    //    [StringLength(20)]
    //    public string LeaveName { get; set; }
    //    public float MinUnit { get; set; }
    //    public int Unit { get; set; }
    //    public int RemaindProc { get; set; }
    //    public int RemaindCount { get; set; }
    //    [StringLength(4)]
    //    public string ReportSymbol { get; set; }
    //    public float Deduct { get; set; }
    //    public int Color { get; set; }
    //    public int Classify { get; set; }
    //    public string Calc { get; set; }
    //}
    //public class NUM_RUN
    //{[Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int NUM_RUNID { get; set; }
    //    public int OLDID { get; set; }
    //    public DateTime STARTDATE { get; set; }
    //    public DateTime ENDDATE { get; set; }
    //    public int CYLE { get; set; }
    //    public int UNITS { get; set; }
    //}
    //public class NUM_RUN_DEIL
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int NUM_RUNID { get; set; }
    //    public DateTime STARTTIME { get; set; }
    //    public DateTime ENDTIME { get; set; }
    //    public int SDAYS { get; set; }
    //    public int EDAYS { get; set; }
    //    public int SCHCLASSID { get; set; }
    //}
    //public class SchClass
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int schClassid { get; set; }
    //    [StringLength(20)]
    //    public string schName { get; set; }
    //    public DateTime StartTime { get; set; }
    //    public DateTime EndTime { get; set; }
    //    public int LateMinutes { get; set; }
    //    public int EarlyMinutes { get; set; }
    //    public int CheckIn { get; set; }
    //    public int CheckOut { get; set; }
    //    public DateTime CheckInTime1 { get; set; }
    //    public DateTime CheckInTime2 { get; set; }
    //    public DateTime CheckOutTime1 { get; set; }
    //    public DateTime CheckOutTime2 { get; set; }
    //    public int Color { get; set; }
    //    public int AutoBind { get; set; }
    //}
    //public class SECURITYDETAILS
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int SECURITYDETAILID { get; set; }
    //    public int USERID { get; set; }
    //    public int DEPTID { get; set; }
    //    public int SCHEDULE { get; set; }
    //    public int USERINFO { get; set; }
    //    public int ENROLLFINGERS { get; set; }
    //    public int REPORTVIEW { get; set; }
    //    public string REPORT { get; set; }
       
    //}
    //public class SHIFT
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int SHIFTID { get; set; }
    //    public string NAME { get; set; }
    //    public int USHIFTID { get; set; }
    //    public DateTime STARTDATE { get; set; }
    //    public DateTime ENDDATE { get; set; }
    //    public int RUNNUM { get; set; }
    //    public int SCH1 { get; set; }
    //    public int SCH2 { get; set; }
    //    public int SCH3 { get; set; }
    //    public int SCH4 { get; set; }
    //    public int SCH5 { get; set; }
    //    public int SCH6 { get; set; }
    //    public int SCH7 { get; set; }
    //    public int SCH8 { get; set; }
    //    public int SCH9 { get; set; }
    //    public int SCH10 { get; set; }
    //    public int SCH11 { get; set; }
    //    public int SCH12 { get; set; }
    //    public int CYCLE { get; set; }
    //    public int UNITS { get; set; }
    //}
    //public class TEMPLATES
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int TEMPLATEID { get; set; }
    //    public int USERID { get; set; }
    //    public int FINGERID { get; set; }
    //    public string TEMPLATE { get; set; }
    //    public string TEMPLATE2 { get; set; }
    //    public string TEMPLATE3 { get; set; }
    //    public string BITMAPPICTURE { get; set; }
    //    public string BITMAPPICTURE2 { get; set; }
    //    public string BITMAPPICTURE3 { get; set; }
    //    public string BITMAPPICTURE4 { get; set; }
    //    public int USETYPE { get; set; }
    //}
    //public class USER_OF_RUN
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int USERID { get; set; }
    //    public int NUM_OF_RUN_ID { get; set; }
    //    public DateTime STARTDATE { get; set; }
    //    public DateTime ENDDATE { get; set; }
    //    public int ISNOTOF_RUN { get; set; }
    //    public int TEMPLATE3 { get; set; }
    //}
    //public class USER_SPEDAY
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int USERID { get; set; }
    //    public DateTime STARTSPECDAY { get; set; }
    //    public DateTime ENDSPECDAY { get; set; }
    //    public int DATEID { get; set; }
    //    [StringLength(200)]
    //    public string YUANYING { get; set; }
    //    public DateTime DATE { get; set; }
    //}
    //public class USER_TEMP_SCH
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int USERID { get; set; }
    //    public DateTime COMETIME { get; set; }
    //    public DateTime LEAVETIME { get; set; }
    //    public int TYPE { get; set; }
    //    public int FLAG { get; set; }
    //    public int SCHCLASSID { get; set; }
    //}
    //public class USERINFO
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int USERID { get; set; }
    //    [StringLength(12)]
    //    public string BADGENUMBER { get; set; }
    //    [StringLength(20)]
    //    public string SSN { get; set; }
    //    [StringLength(20)]
    //    public string NAME { get; set; }
    //    [StringLength(2)]
    //    public string GENDER { get; set; }
    //    [StringLength(20)]
    //    public string TITLE { get; set; }
    //    [StringLength(20)]
    //    public string PAGER { get; set; }
    //    public DateTime BIRTHDAY { get; set; }
    //    public DateTime HIREDDAY { get; set; }
    //    [StringLength(40)]
    //    public string STREET { get; set; }
    //    [StringLength(2)]
    //    public string CITY { get; set; }
    //    [StringLength(2)]
    //    public string STATE { get; set; }
    //    [StringLength(12)]
    //    public string ZIP { get; set; }
    //    [StringLength(20)]
    //    public string OPHONE { get; set; }
    //    [StringLength(20)]
    //    public string FPHONE { get; set; }
    //    public int VERIFICATIONMETHOD { get; set; }
    //    public int DEFAULTDEPTID { get; set; }
    //    public int SECURITYFLAGS { get; set; }
    //    public int ATT { get; set; }
    //    public int INLATE { get; set; }
    //    public int OUTEARLY { get; set; }
    //    public int OVERTIME { get; set; }
    //    public int SEP { get; set; }
    //    public int HOLIDAY { get; set; }
    //    [StringLength(8)]
    //    public string MINZU { get; set; }
    //    [StringLength(20)]
    //    public string PASSWORD { get; set; }
    //    public int LUNCHDURATION { get; set; }
    //    [StringLength(10)]
    //    public string MVerifyPass { get; set; }
    //    public string PHOTO { get; set; }
    //}
}