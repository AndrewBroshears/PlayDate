using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public ICollection<Park> Park { get; set; } = new List<Park>();
    }
}
