using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayDate.Data
{
    public class Rating
    {
        [Required]
        public int RatingId { get; set; }
        [Required]
        public int RatingStar { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

    }
}
