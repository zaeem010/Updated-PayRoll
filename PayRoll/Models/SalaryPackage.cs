using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayRoll.Models
{
    public class SalaryPackage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Name { get; set; }
        public string BasicSalary { get; set; }
        public string MedicalAllowance { get; set; }
        public string HouseRent { get; set; }
        public string Total { get; set; }
        public int Comid { get; set; }
    }
}