using System.ComponentModel.DataAnnotations;

namespace APIApplication.Models.Request
{
    public class LoginRequest
    {

        //public Guid Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        public string Password { get; set; } = string.Empty;

        //public string Role { get; set; } = string.Empty;


    }
}
