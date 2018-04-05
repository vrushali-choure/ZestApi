using HRInnova.Data.Repository;
using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_ZEST.AppCode;
using WebAPI_ZEST.Helpers;
using WebAPI_ZEST.Models;

namespace ProductsApp.Controllers
{
    public class ProbationPeriodController : ApiController
    {                
        [HttpPost]
        public IHttpActionResult GetProbationPeriodDetails(EmployeeDetails emp)
        {
            var response_from_stored_proc = StoredProcedureRepository.GetEmployeeDetails(emp.EmpID);
            
            if (response_from_stored_proc == null)
            {
                return NotFound();
            }          
            var response = WebMethods.CreateServiceResponse(Enums.WebServiceStatus.Success, response_from_stored_proc);         
            return Json(response);
        }
    }
}
