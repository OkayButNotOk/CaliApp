using Caliapp.Shared.Helpers;
using CaliApp.Application.DTOs;
using CaliApp.Application.Interfaces;
using CaliApp.Domain.Entities;
using CaliApp.Infrastructure.Presistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Caliapp.Application.Services
{
    public class AuthService(AppDbContext db, IConfiguration config) : IAuthService
    {
        private readonly AppDbContext _db = db;
        private readonly IConfiguration _config = config;

        public async Task RegisterAsync(RegisterRequest request)
        {
            if (await _db.Users.AnyAsync(u => u.Email == request.Email))
                throw new Exception("This email is already in use.");

            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = new PasswordHasher<User>().HashPassword(null, request.Password),
                Role = "UserRole.FreeUser.ToString()",
                FitnessLevel = "FitnessLevel.Beginner.ToString()"
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null || !new PasswordHasher<User>().VerifyHashedPassword(null, user.PasswordHash, request.Password).Equals(Microsoft.AspNet.Identity.PasswordVerificationResult.Success))
                throw new Exception("Invalid email or password.");

            var token = JwtGenerator.GenerateToken(user.Id, user.Role, _config["Jwt:Secret"] ?? throw new InvalidOperationException("JWT secret is not configured."));

            return new AuthResponse
            {
                Token = token,
                UserId = user.Id,
                Role = user.Role
            };
        }
    }
}
