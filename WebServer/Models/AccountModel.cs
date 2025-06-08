using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebServer.Models
{
    public class AccountModel : BaseEntity
    {
        [Key]
        public uint UserId { get; set; }

        [Required]
        [MaxLength(320)]
        public required string Email { get; set; }

        [MaxLength(255)]
        public string? Password { get; set; }

        public bool IsEmailVerified { get; set; } = false;

        public DateTime withdrawalDate { get; set; } = DateTime.MinValue;
    }
}
