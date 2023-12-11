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
    public class UserOperationRule: IUserOperationRule
    {

        private readonly IUserRepository _userRepository;

        public UserOperationRule(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string AddUserRule(Users user)
        {
            string status = "";
            if(user is not  null && user.Age >=18)
            {
                    _userRepository.AddUser(user);
                    status = "User added successfully.";
            }
            else
            {
                status = "Adding user failed.";
            }
            
            return status;
        }

        public string UpdateUserRule(Users user)
        {
            string status = "";
            if (user is not null)
            {
                if (user.Gender != "male" || user.Gender != "female")
                {
                    _userRepository.UpdateUser(user);
                    status = "User updated successfully.";
                }
            }
            else
            {
                status = "Updating user failed.";
            }

            return status;
        }

        public string DeleteUserRule(int userId)
        {
            string status = "";
            if (userId >= 0)
            {
                _userRepository.DeleteUser(userId);
                status = "User removed successfully.";
            }
            else
            {
                status = "UserId cannot be smaller or equal to 0";
            }
            return status;
        }

        public Users GetUserById(int userId)
        {
            Users user = new Users();
            if (userId > 0)
            {
                user = _userRepository.GetUserById(userId);
            }
             
            return user;
        }

        public IEnumerable<Users> GetAllUsers()
        {

            return _userRepository.GetAllUsers();
        }

        
    }
}
