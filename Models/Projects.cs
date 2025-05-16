using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace Portfolio.Server.Models
{
    public class Projects
    {
        [Key]
        [Column("ID")]
        public int ProjectId { get; set; }

        [Column("ProjectName")]
        public string ProjectName { get; set; } = string.Empty;

        [Column("ProjectDescription")]
        public string ProjectDescription { get; set; } = string.Empty;

        [Column("UserID")]
        public int UserId { get; set; } // Renamed to match ForeignKey casing

        [ForeignKey("UserId")]
        [InverseProperty("Projects")] // Points to the Projects property in UserProfile
        [JsonIgnore]
        public virtual UserProfiles? UserProfile { get; set; } 
    }
}
