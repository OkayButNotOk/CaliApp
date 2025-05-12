namespace CaliApp.Application.DTOs
{
    public class AuthResponse
    {
        public string Token { get; set; } = null!;
        public int UserId { get; set; }
        public string Role { get; set; } = null!;
    }
}
