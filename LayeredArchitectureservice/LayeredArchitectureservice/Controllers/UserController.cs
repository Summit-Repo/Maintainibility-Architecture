using Application;
using AutoMapper;
using DataAccess;
using DataAccess.Domain;
using DataAccess.Repository;
using LayeredArchitectureservice.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LayeredArchitectureservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserOperationRule _userOperationRule;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper,IConfiguration configuration)
        {

            _userOperationRule = new UserOperationRule(configuration);
            _mapper = mapper;

        }


        [HttpPost]
        public IActionResult AddUser([FromBody] UserDto userCreateDto)
        {
            var user = _mapper.Map<Users>(userCreateDto);
            var status = _userOperationRule.AddUserRule(user);

            return Ok(new { Status = status });
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser(int userId, [FromBody] UserDto userUpdateDto)
        {
            var existingUser = _userOperationRule.GetUserById(userId);

            if (existingUser == null) return NotFound(new { Status = "User not found." });


            var updatedUser = _mapper.Map(userUpdateDto, existingUser);
            var status = _userOperationRule.UpdateUserRule(updatedUser);

            return Ok(new { Status = status });
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            var status = _userOperationRule.DeleteUserRule(userId);
            return Ok(new { Status = status });
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserById(int userId)
        {
            var user = _userOperationRule.GetUserById(userId);
            var userDto = _mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userOperationRule.GetAllUsers();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);

            return Ok(userDtos);
        }
    }

}

