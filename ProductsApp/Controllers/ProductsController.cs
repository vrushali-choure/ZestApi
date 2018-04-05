using WebAPI_ZEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_ZEST.AppCode;
using ProductsApp.Models;
using WebAPI_ZEST.Helpers;

namespace WebAPI_ZEST.Controllers
{
    public class ProductsController : ApiController
    {
        
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        [JwtAuthentication]
        [HttpPost]
        public IHttpActionResult GetProduct(TestRequest test)
        {
            var product = products.FirstOrDefault((p) => p.Id == test.id);
            if (product == null)
            {
                return NotFound();
            }
            var response = WebMethods.CreateServiceResponse(Enums.WebServiceStatus.Success, product);
            return Json(response);
        }
    }
}
