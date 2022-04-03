using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayDate.Models
{
    public class ParkCreate
    {
        [Required]
        public string ParkName { get; set; }
        [Required]
        public string ParkAddress { get; set; }
    }
}
