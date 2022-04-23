using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayDate.Models
{
    public class AmenityDetail
    {
        [Display(Name ="Amenity ID")]
        public int AmenityId { get; set; }
        [Display(Name ="Amenity Type")]
        public string AmenityType { get; set; }
    }
}
