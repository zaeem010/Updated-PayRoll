using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayRoll.Models
{
    public class UserLogin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int Comid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class UserAccess
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int Form_id { get; set; }
        public int SubForm_id { get; set; }
        public int SuperForm_id { get; set; }
        public int Comid { get; set; }
        public string Username { get; set; }
    }
}