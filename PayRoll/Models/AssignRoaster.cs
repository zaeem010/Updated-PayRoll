using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayRoll.Models
{
    public class AssignRoaster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Day { get; set; }
        public int Roasterid { get; set; }
        public int Shiftid { get; set; }
        public int Comid { get; set; }
    }
}