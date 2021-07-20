using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PayRoll.Models
{
    public class RoasterUpdate
    {
        [Key]
        public int id { get; set; }
        public int Roasterid { get; set; }
        public DateTime Date { get; set; }
        public string EmpCode { get; set; }
        public string Comid { get; set; }
    }
    public class RestdayUpdate
    {
        [Key]
        public int id { get; set; }
        public string Restday { get; set; }
        public DateTime Date { get; set; }
        public string EmpCode { get; set; }
        public string Comid { get; set; }
    }
}