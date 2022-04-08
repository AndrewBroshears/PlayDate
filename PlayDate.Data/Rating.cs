using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayDate.Data
{
    public class Rating
    {
        [Key]
        [Required]
        public int RatingId { get; set; }
        [Required]
        public int RatingStar { get; set; }
        [Required]
        public string RatingComment { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        
        [ForeignKey(nameof(Park))]
        public int ParkId { get; set; }
        public virtual Park Park { get; set; }

    }
}
