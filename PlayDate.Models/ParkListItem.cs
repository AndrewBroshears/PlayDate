using PlayDate.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayDate.Models
{
    public class ParkListItem
    {
        [Display(Name ="Park ID")]
        public int ParkId { get; set; }
        [Display(Name ="Park Name")]
        public string ParkName { get; set; }
        [Display(Name ="Address")]
        public string ParkAddress { get; set; }
        [Display(Name ="Amenity ID")]
        public int AmenityId { get; set; }
        public virtual Amenity Amenity { get; set; }
        //public string AmenityType { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}
