using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SportsStore.Controllers
{
    public class ProductsController : ApiController
    {
        private IRepository Repository { get; set; }

        public ProductsController()
        {
            Repository = (IRepository)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IRepository));
        }

        public IEnumerable<Product> GetProducts()
        {
            return Repository.Products;
        }

        //Use HttpResponseException to handle validation
        //public Product GetProduct(int id)
        //{
        //    var product = Repository.Products.Where(p => p.Id == id).FirstOrDefault();
        //    if (product == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);
        //    }
        //    return product;
        //}

        public IHttpActionResult GetProduct(int id)
        {
            Product result = Repository.Products.Where(p => p.Id == id).FirstOrDefault();
            return result == null ? (IHttpActionResult)BadRequest("No Product Found") : Ok(result);
        }

        //Simple Edition
        //[Authorize(Roles ="Administrators")]
        //public async Task PostProduct(Product product)
        //{
        //    await Repository.SaveProductAsync(product);
        //}

        //Added validation
        [Authorize(Roles = "Administrators")]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await Repository.SaveProductAsync(product);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize(Roles = "Administrators")]
        public async Task DeleteProduct(int id)
        {
            await Repository.DeleteProductAsync(id);
        }
    }
}
