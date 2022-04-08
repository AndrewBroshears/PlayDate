using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayDate.Models
{
    public class AmenityListItem
    {
        [Key]
        public int AmenityId { get; set; }
        [Required]
        public string AmenityType { get; set; }
    }
}
