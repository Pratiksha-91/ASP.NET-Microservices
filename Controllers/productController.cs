using Microsoft.AspNetCore.Mvc;
using servicefirst.Models;
using servicefirst.Services;
using servicefirst.serviceimp;

namespace servicefirst.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class productController : Controller
    {

        private readonly Iproduct _product;

        public productController(Iproduct product)
        {
            _product = product;
        }

        [HttpPost]
        public string AddProduct(product productData)
        {
            var result = _product.AddProduct(productData);

            return "Product Added!";
        }

        [HttpGet]
        public List<product> getproducts(int pid)
        {
            List<product> products = new List<product>();
            products =  _product.GetProducts(pid);

            return products;

         
        }
    }
}
