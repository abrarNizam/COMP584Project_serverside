using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Server.Models
{
    public class UserProfiles
    {
        [Key]
        [Column("ID")]
        public int UserID { get; set; }

        [Column("UserName")]
        [StringLength(50)]
        [Unicode(false)]
        public string UserName { get; set; } = string.Empty;

        [Column("UserEmail")]
        [StringLength(100)] // Increased length for email
        [Unicode(false)]
        public string UserEmail { get; set; } = string.Empty;

        [InverseProperty("UserProfile")] // Points to the UserProfile property in Project
        public virtual ICollection<Projects> Projects { get; set; } = new List<Projects>();
    }
}
