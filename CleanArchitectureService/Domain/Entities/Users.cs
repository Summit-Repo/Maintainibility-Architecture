using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string Gender { get; set; }
        public string Phone { get; set; }

        public int Age { get; set; }

    }
}
