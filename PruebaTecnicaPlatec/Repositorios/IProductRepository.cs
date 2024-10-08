using PruebaTecnicaPlatec.Models;

namespace PruebaTecnicaPlatec.Repositorios
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();
        public Product GetProductsId(int id);
        public String PostProduct(Product product);
        public String PutProduct(Product product);
        public String DeleteProduct(int id);
    }
}
