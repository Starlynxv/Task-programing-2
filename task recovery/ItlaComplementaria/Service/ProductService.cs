using ItlaComplementaria.Interfaces;
using ItlaComplementaria.Models;

namespace ItlaComplementaria.Services
{
    public class ProductService : IProductService
    {
        private static readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Example Item", Price = 99.99m }
        };

        public IEnumerable<Product> GetAll() => _products;

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            product.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index != -1) _products[index] = product;
        }

        public void Delete(int id) => _products.RemoveAll(p => p.Id == id);
    }
}