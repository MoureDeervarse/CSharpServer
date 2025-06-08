using System.ComponentModel.DataAnnotations;

namespace WebServer.Models
{
    public class DeviceInfoModel : BaseEntity
    {
        public uint UserId { get; set; }

        [MaxLength(128)]
        public required string DeviceId { get; set; }

        [MaxLength(255)]
        public string? FcmToken { get; set; }

        public bool IsAllowAlarm { get; set; } = true;
    
        public bool IsAllowNightAlarm { get; set; } = false;
    
        public DateTime AllowNightAlarmAt { get; set; } = DateTime.MinValue;
    }
}
