namespace CaliApp.Application.DTOs
{
    public class RegisterRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Role { get; set; } = "FreeUser";
        public string FitnessLevel { get; set; } = "Beginner";
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

    }
}
