using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IUserRepository
    {
        Users GetUserById(int userId);
        IEnumerable<Users> GetAllUsers();
        void AddUser(Users user);
        void UpdateUser(Users user);
        void DeleteUser(int userId);
    }
}
