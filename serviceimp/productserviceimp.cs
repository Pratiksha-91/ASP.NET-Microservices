using servicefirst.Data;
using servicefirst.Models;
using servicefirst.Services;

namespace servicefirst.serviceimp
{
    public class productserviceimp : Iproduct
    {
        private readonly ContextClass _context;
        public productserviceimp(ContextClass context) {
           _context = context;
        }
        public string AddProduct(product productData)
        {
            _context.Products.Add(productData);
            _context.SaveChanges();
            return "Added Product";
        }

        public List<product> GetProducts(int id)
        {
            List<product> products = new List<product>();

            var productId =  _context.Products.Find(id);

            if (productId != null)
            {
                products = _context.Products.ToList();

            }

            return products;

        }
    }
}
