﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EinsteinHacking.Models
{
    public class Hint : BaseModel
    {
        [Key]
        public int HintID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
    }
}
