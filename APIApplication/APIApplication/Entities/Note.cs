using APIApplication.Services.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIApplication.Entities
{
    public class Note: ITrackTimestamps
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; } = string.Empty;

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        // Navigation property
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
