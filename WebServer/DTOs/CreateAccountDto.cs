using System.ComponentModel.DataAnnotations;

namespace WebServer.DTOs
{
    public class CreateAccountDto
    {
        [Required]
        [MaxLength(320)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? Password { get; set; }
    }
}
