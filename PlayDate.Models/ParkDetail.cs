using PlayDate.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayDate.Models
{
    public class ParkDetail
    {
        [Display(Name ="Park ID")]
        public int ParkId { get; set; }
        [Display(Name ="Park Name")]
        public string ParkName { get; set; }
        [Display(Name ="Park Address")]
        public string ParkAddress { get; set; }
        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name ="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        [Display(Name ="Amenity ID")]
        public int AmenityId { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}
