using System.ComponentModel.DataAnnotations;

namespace WebServer.Models
{
    public class SocialInfoModel : BaseEntity
    {
        public uint UserId { get; set; }

        public byte SocialType { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Token { get; set; }
    }
}
