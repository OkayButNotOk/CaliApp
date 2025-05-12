using System;
using System.ComponentModel.DataAnnotations;

namespace CaliApp.Domain.Entities
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        [Required]
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets the hashed password of the user.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; private set; } = string.Empty;

        /// <summary>
        /// Gets or sets the hashed password string.
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string PasswordHash { get; internal set; } = string.Empty;

        /// <summary>
        /// Gets or sets the full name of the user.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
        public string FullName { get; internal set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the role of the user.
        /// Consider using an enum in place of string.
        /// </summary>
        public string Role { get; set; } = "FreeUser";

        /// <summary>
        /// Gets or sets the fitness level of the user.
        /// Consider using an enum in place of string.
        /// </summary>
        public string FitnessLevel { get; set; } = "Beginner";

        /// <summary>
        /// Gets or sets the height of the user.
        /// </summary>
        public decimal Height { get; set; }

        /// <summary>
        /// Gets or sets the weight of the user.
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// Gets the created date in UTC.
        /// </summary>
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    }
}
