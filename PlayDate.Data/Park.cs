using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayDate.Data
{
    public class Park
    {
        [Key]
        [Required]
        public int ParkId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string ParkName { get; set; }
        [Required]
        public string ParkAddress { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        [ForeignKey(nameof(Amenity))]
        public int AmenityId { get; set; }
        public virtual Amenity Amenity { get; set; }

        public ICollection<Rating> Ratings { get; set; }


    }
}
