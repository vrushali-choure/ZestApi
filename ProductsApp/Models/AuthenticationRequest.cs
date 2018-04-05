using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_ZEST.Models
{
    public class AuthenticationRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AuthenticationType { get; set; }
    }
}