using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_ZEST.Helpers;

namespace WebAPI_ZEST.Models
{
    public class ServiceResponse
    {
        private object responseJson;

        // Success = 0, Other Success Flags > 0, Error Flags < 0
        public int Status { get; set; }

        public string ServerDateTime
        {
            get { return DateTime.UtcNow.ToString("MMM dd yyyy hh:mm tt"); }
        }

        public List<string> ErrorList { get; set; }

        public object ResponseJSON
        {
            get { return this.responseJson; }
            set { this.responseJson = JsonMethods.CreateJsonResponse(value); }
        }
    }
}