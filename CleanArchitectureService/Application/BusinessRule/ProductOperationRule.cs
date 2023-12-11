using Application.IBusinessRule;
using Domain.Entities;
using Domain.IRepository;       
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessRule
{
    public class ProductOperationRule:IProductOperationRule
    {

        private readonly IProductRepository _productRepository;

        public ProductOperationRule(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public string AddProductRule(Product product)
        {
            string status = "";
            if (product is not null && product.Price >= 100)
            {
                _productRepository.AddProduct(product);
                status = "Product added successfully.";
            }
            else
            {
                status = "Adding product failed.";
            }

            return status;
        }

        public string UpdateProductRule(Product product)
        {
            string status = "";
            if (product is not null)
            {
                if (product.Quantity >= 0)
                {
                    _productRepository.UpdateProduct(product);
                    status = "Product updated successfully.";
                }
            }
            else
            {
                status = "Updating product failed.";
            }

            return status;
        }

        public string DeleteProductRule(int productId)
        {
            string status = "";
            if (productId >= 0)
            {
                _productRepository.DeleteProduct(productId);
                status = "User removed successfully.";
            }
            else
            {
                status = "UserId cannot be smaller or equal to 0";
            }
            return status;
        }

        public Product GetProductById(int productId)
        {
            Product product = new Product();
            if (productId > 0)
            {
                product = _productRepository.GetProductById(productId);
            }
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {

            return _productRepository.GetAllProducts();
        }
    }
}

