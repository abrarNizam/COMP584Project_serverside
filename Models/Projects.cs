using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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
        public virtual UserProfiles UserProfile { get; set; } // Removed nullable marker
    }
}
