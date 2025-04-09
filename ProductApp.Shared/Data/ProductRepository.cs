using ProductApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Shared.Data
{
    public static class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.99m },
            new Product { Id = 2, Name = "Product 2", Price = 20.99m },
            new Product { Id = 3, Name = "Product 3", Price = 30.99m }
        };

        public static List<Product> GetAll() => _products;
        public static Product GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public static void Add(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);
        }

        public static void Update(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            var existingProduct = GetById(product.Id);
            if (existingProduct == null) throw new KeyNotFoundException($"Product with ID {product.Id} not found.");
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
        }

        public static void Delete(int id)
        {
            var product = GetById(id);
            if (product == null) throw new KeyNotFoundException($"Product with ID {id} not found.");
            _products.Remove(product);
        }

    }
}
