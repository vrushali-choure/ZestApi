using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebAPI_ZEST.Helpers;
using WebAPI_ZEST.Models;

namespace WebAPI_ZEST.AppCode
{
    public class WebMethods
    {

        /// <summary>
        /// Creates the service response.
        /// </summary>
        /// <param name="serviceStatus">The service status.</param>
        /// <param name="resultOrErrors">The result or errors.</param>
        /// <returns>
        /// returns ServiceResponse.
        /// </returns>
        public static ServiceResponse CreateServiceResponse(Enums.WebServiceStatus serviceStatus, object resultOrErrors)
        {
            var response = new ServiceResponse();

            if (serviceStatus == Enums.WebServiceStatus.Success)
            {
                response.Status = (int)serviceStatus;
                response.ResponseJSON = resultOrErrors;
            }
            else
            {
                response.ErrorList = resultOrErrors as List<string>;
                response.Status = (int)serviceStatus;
            }

            return response;
        }

        /// <summary>
        /// Creates the service response message.
        /// </summary>
        /// <param name="serviceStatus">The service status.</param>
        /// <param name="message">The message.</param>
        /// <returns>returns string</returns>
        public static ServiceResponse CreateServiceResponseMessage(Enums.WebServiceStatus serviceStatus, string message)
        {
            return CreateServiceResponse(serviceStatus, new List<string>() { message });
        }

        /// <summary>
        /// Creates the service response for required request json.
        /// </summary>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// return ServiceResponse.
        /// </returns>
        public static ServiceResponse CreateServiceResponseWithErrors(params string[] errors)
        {
            var response = new ServiceResponse();
            response.ErrorList = errors.ToList();
            response.Status = (int)Enums.WebServiceStatus.Failure;
            return response;
        }

        public static bool SkipAuthorization(HttpActionContext actionContext)
        {
            if (!actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
            {
                return actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
            }

            return true;

            //return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
            //       || actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }

        public static string GetBaseUrl()
        {
            var request = HttpContext.Current.Request;
            return request.Url.Scheme + "://" + request.Url.Authority + request.ApplicationPath.TrimEnd('/');
        }

    }
}