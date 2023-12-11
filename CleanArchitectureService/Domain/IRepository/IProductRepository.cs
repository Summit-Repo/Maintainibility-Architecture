using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IProductRepository
    {
        public Product GetProductById(int productId);

        public IEnumerable<Product> GetAllProducts();

        public void AddProduct(Product product);

        public void UpdateProduct(Product product);

        public void DeleteProduct(int productId);

    }
}
