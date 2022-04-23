using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayDate.Data
{
    public class Amenity
    {
        [Key]
        [Required]
        public int AmenityId { get; set; }
        [Required]
        public string AmenityType { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public Guid OwnerId { get; set; }

        public ICollection<Park> Parks { get; set; } = new List<Park>();
    }
}
