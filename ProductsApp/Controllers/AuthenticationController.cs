using WebAPI_ZEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_ZEST.Helpers;
using WebAPI_ZEST.AppCode;
using System.Configuration;

namespace WebAPI_ZEST.Controllers
{
    public class AuthenticationController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult UserLogin(AuthenticationRequest objAuthenticationRequest)
        {
            AuthenticationRequest au = new AuthenticationRequest();
            
            ServiceResponse response = null;
            try
            {
                if (string.IsNullOrEmpty(objAuthenticationRequest.UserName))
                {
                    ModelState.AddModelError("UserName", "Please Enter Username.");
                }
                if (objAuthenticationRequest.AuthenticationType.ToLower() == "FORM" && string.IsNullOrEmpty(objAuthenticationRequest.Password))
                {
                    ModelState.AddModelError("Password", "Please Enter Password.");
                }

                if (!ModelState.IsValid)
                {
                    List<string> modelErrors = new List<string>();
                    foreach (var modelState in ModelState.Values)
                    {
                        foreach (var modelError in modelState.Errors)
                        {
                            modelErrors.Add(modelError.ErrorMessage);
                        }
                    }

                    response = WebMethods.CreateServiceResponse(Enums.WebServiceStatus.Invalid, modelErrors);
                }
                else
                {
                    AuthenticationResponse objAuthenticationResponse = new AuthenticationResponse();

                    string Token = JwtManager.GenerateToken(objAuthenticationRequest.UserName, Convert.ToInt32(ConfigurationManager.AppSettings["TokenExpireMinutes"]));

                    objAuthenticationResponse.AuthorizationToken = "Bearer " + Token;
                    response = WebMethods.CreateServiceResponse(Enums.WebServiceStatus.Success, objAuthenticationResponse);

                }

            }
            catch (Exception ex)
            {
                List<string> ErrorList = new List<string>();
                ErrorList.Add(ex.Message);
                response = WebMethods.CreateServiceResponse(Enums.WebServiceStatus.ServerError, ErrorList);
            }

            return Json(response);
        }
    }
}
