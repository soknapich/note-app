using System.ComponentModel.DataAnnotations;

namespace APIApplication.Models.Respone
{
    public class UserRespone
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
    }
}
