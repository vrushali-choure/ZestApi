using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_ZEST.Helpers
{
    public class Enums
    {
        public enum WebServiceStatus
        {
            Success = 100,
            Invalid = 101,
            ServerError = 102,
            Failure = 103,
            TokenInvalid = 104,
            TokenValid = 105,
            BadRequest = 106,
            InvalidCredentials = 107
        }
    }
}
