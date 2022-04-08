﻿using PlayDate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayDate.Models
{
    public class RatingListItem
    {
        public int RatingId { get; set; }
        public int RatingStar { get; set; }
        public string RatingComment { get; set; }

        public int ParkId { get; set; }
        public virtual Park Park { get; set; }
    }
}
