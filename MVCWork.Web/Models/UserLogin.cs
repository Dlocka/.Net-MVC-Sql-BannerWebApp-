using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVCWork.Web.Models
{
    public class UserLogin
    {
        [DisplayName("User name")]
        public string UserName { get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}