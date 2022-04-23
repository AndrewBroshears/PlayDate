using PlayDate.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayDate.Models
{
    public class ParkEdit
    {
        [Required]
        public int ParkId { get; set; }
        [Required, Display(Name ="Park Name")]
        public string ParkName { get; set; }
        [Required, Display(Name ="Park Address")]
        public string ParkAddress { get; set; }
        [Display(Name ="Amenity")]
        public int AmenityId { get; set; }
        public virtual Amenity Amenity { get; set; }
        

        //public ICollection<Rating> Ratings { get; set; }
    }
}
