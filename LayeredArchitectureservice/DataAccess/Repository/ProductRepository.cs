using DataAccess.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository

    {
        private readonly Context _context;

        public ProductRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("artifactDbContext");


            var dbContextOptions = new DbContextOptionsBuilder<Context>()
               .UseSqlServer(connectionString)
               .Options;

            _context = new Context(dbContextOptions);


        }

        public Product GetProductById(int productId)
        {
            return _context.Products.Find(productId);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Users.Find(productId);
            if (product != null)
            {
                _context.Users.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
