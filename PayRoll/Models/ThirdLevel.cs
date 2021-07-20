using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayRoll.Models
{
    public class ThirdLevel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int AccountNo { get; set; }
        public int Headid { get; set; }
        public int SubHeadid { get; set; }
        public int SecondHeadid { get; set; }
        public string AccountTitle { get; set; }
        public string AccountType { get; set; }
        public decimal Dr { get; set; }
        public decimal Cr { get; set; }
        public int Comid { get; set; }
    }
}