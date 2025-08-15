namespace APIApplication.Models.Respone
{
    public class RefreshTokenRespone
    {
        public Guid UserId { get; set; }
        public required string RefreshToken  { get; set; } 

    }
}
