using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebAPI_ZEST.Helpers;

namespace WebAPI_ZEST.AppCode
{
    public class RequestHandler : DelegatingHandler
    {
        /// <summary>
        /// Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
        /// </summary>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        /// <returns>
        /// Returns <see cref="T:System.Threading.Tasks.Task`1" />. The task object representing the asynchronous operation.
        /// </returns>
        protected async override Task<HttpResponseMessage> SendAsync(
               HttpRequestMessage request,
               CancellationToken cancellationToken)
        {
            try
            {
                // check if request is encrypted or non encrypted
                var isNonEncRequest = request.Headers.FirstOrDefault(r => r.Key == "Non-Encrypt-Request");
                bool? isNonEncrypted = null;
                if (!string.IsNullOrWhiteSpace(isNonEncRequest.Key))
                {
                    isNonEncrypted = true;
                }

                var contentType = request.Content.Headers.ContentType;
                var oldHeaders = request.Content.Headers;


                if (contentType != null)
                {
                    if (contentType.MediaType.StartsWith("application/x-www-form-urlencoded", StringComparison.OrdinalIgnoreCase))
                    {
                        return request.CreateResponse(WebMethods.CreateServiceResponseWithErrors("Error"));
                    }

                    if (contentType.MediaType.StartsWith("multipart/form-data", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!request.Content.IsMimeMultipartContent())
                        {
                            return request.CreateResponse(WebMethods.CreateServiceResponseWithErrors("Error"));
                        }

                        var requestJson = HttpContext.Current.Request.Params["RequestJSON"];
                        if (requestJson != null)
                        {
                            var requestObj = JsonMethods.JObjectParse(requestJson);
                            var requestContent = requestObj["RequestJSON"];

                            if (requestContent != null)
                            {
                                var jsonData = JsonMethods.CreateJsonRequest(requestContent.ToString(), !isNonEncrypted);
                                request.Content = new StringContent(jsonData);

                                // webapi is not supporting multipart/form-data so request can not redirect to particular action
                                // multipart is possible if action don't have any parameters
                                oldHeaders.Remove("Content-type");
                                oldHeaders.Add("Content-type", "application/json");
                            }
                            else
                            {
                                return request.CreateResponse(WebMethods.CreateServiceResponseWithErrors("Error"));
                            }
                        }
                        else
                        {
                        }
                    }
                    else if (contentType.MediaType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase) || contentType.MediaType.StartsWith("text/json", StringComparison.OrdinalIgnoreCase))
                    {
                        var formData = request.Content.ReadAsStringAsync().Result;
                        var requestObj = JsonMethods.JObjectParse(formData);
                        var requestContent = requestObj["RequestJSON"];

                        if (requestContent != null)
                        {
                            if (requestContent.ToString() != "{}")
                            {
                                var jsonData = JsonMethods.CreateJsonRequest(requestContent.ToString(), !isNonEncrypted);
                                request.Content = new StringContent(jsonData);
                            }
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        //new Exception(CommonResources.GetError("UnsupportedContentType")).LogToElmah();
                    }
                }

                this.ReplaceHeaders(request.Content.Headers, oldHeaders);
                var response = await base.SendAsync(request, cancellationToken);

                return response;
            }
            catch (Exception exception)
            {
                var responseMessage = request.CreateResponse(WebMethods.CreateServiceResponseWithErrors("Error"));
                return responseMessage;
            }
        }

        /// <summary>
        /// Replaces the headers.
        /// </summary>
        /// <param name="currentHeaders">The current headers.</param>
        /// <param name="oldHeaders">The old headers.</param>
        private void ReplaceHeaders(HttpContentHeaders currentHeaders, HttpContentHeaders oldHeaders)
        {
            currentHeaders.Clear();
            foreach (var item in oldHeaders)
            {
                currentHeaders.Add(item.Key, item.Value);
            }
        }
    }
}