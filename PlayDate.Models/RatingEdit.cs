using PlayDate.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayDate.Models
{
    public class RatingEdit
    {
        [Required]
        public int RatingId { get; set; }
        [Required]
        public int RatingStar { get; set; }
        [Required]
        public string RatingComment { get; set; }
        
        public int ParkId { get; set; } 
        public virtual Park Park { get; set; }
    }
}
