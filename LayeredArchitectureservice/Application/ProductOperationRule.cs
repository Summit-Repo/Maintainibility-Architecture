using DataAccess.Domain;
using DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ProductOperationRule
    {
        private readonly ProductRepository _productRepository;
        //private readonly AdoProductRepository _adoProductRepository;

        public ProductOperationRule(IConfiguration configuration)
        {
            _productRepository = new ProductRepository(configuration);
            //_adoProductRepository = new AdoProductRepository(configuration);
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
                status = "Product removed successfully.";
            }
            else
            {
                status = "ProductId cannot be smaller or equal to 0";
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
            //return _adoProductRepository.GetAllProducts();
        }

    }

}

