using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IBusinessRule
{
    public interface IProductOperationRule
    {
        public string AddProductRule(Product product);

        public string UpdateProductRule(Product product);

        public string DeleteProductRule(int productId);

        public Product GetProductById(int productId);

        public IEnumerable<Product> GetAllProducts();


    }
}
