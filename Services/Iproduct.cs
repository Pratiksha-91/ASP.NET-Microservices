using servicefirst.Models;

namespace servicefirst.Services
{
    public interface Iproduct
    {
        public string AddProduct(product productData);

        public List<product> GetProducts(int pid);
    }
}
