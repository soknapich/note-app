using APIApplication.Entities;

namespace APIApplication.Models.Respone
{
    public class TokenRespone
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public UserRespone? UserRespone { get; set; }

    }
}
