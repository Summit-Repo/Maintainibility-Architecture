
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
        public class UserRepository 
        {
            private readonly Context _context;

            public UserRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("artifactDbContext");


            var dbContextOptions = new DbContextOptionsBuilder<Context>()
               .UseSqlServer(connectionString)
               .Options;

            _context = new Context(dbContextOptions);


        }
        
        public Users GetUserById(int userId)
            {
                return _context.Users.Find(userId);
            }

            public IEnumerable<Users> GetAllUsers()
            {
                return _context.Users.ToList();
            }

            public void AddUser(Users user)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }

            public void UpdateUser(Users user)
            {
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
            }

            public void DeleteUser(int userId)
            {
                var user = _context.Users.Find(userId);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                }
            }
        }

}
