using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayDate.Data
{
    public enum RatingStar { 
        Excellent=1, 
        Great=2, 
        Okay=3, 
        Lacking=4, 
        Terrible=5}
    public class Rating
    {
        [Key]
        [Required]
        public int RatingId { get; set; }
        [Required]
        public RatingStar RatingStar { get; set; }
        [Required]
        public string RatingComment { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(Park))]
        public int ParkId { get; set; }
        public virtual Park Park { get; set; }

    }
}
