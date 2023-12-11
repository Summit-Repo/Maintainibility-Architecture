using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IBusinessRule
{
    public interface IUserOperationRule
    {
            public string AddUserRule(Users user);
            public string UpdateUserRule(Users user);
            public string DeleteUserRule(int userId);

            public Users GetUserById(int userId);
            public IEnumerable<Users> GetAllUsers();

    }
}
