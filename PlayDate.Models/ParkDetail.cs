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
        public int ParkId { get; set; }
        public string ParkName { get; set; }
        public string ParkAddress { get; set; }
        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name ="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        public int AmenityId { get; set; }
        public virtual Amenity Amenity { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}
