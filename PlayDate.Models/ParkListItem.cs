using PlayDate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayDate.Models
{
    public class ParkListItem
    {
        public int ParkId { get; set; }
        public string ParkName { get; set; }
        public string ParkAddress { get; set; }
        
        public int AmenityId { get; set; }
        
        public ICollection<Rating> Ratings { get; set; }
    }
}
