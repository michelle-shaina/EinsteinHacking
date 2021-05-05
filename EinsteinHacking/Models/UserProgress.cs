using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EinsteinHacking.Models
{
    public class UserProgress : BaseModel
    {
        [Key]
        public int UserProgressID { get; set; }
        public Challenge Challenge { get; set; }
        public Status Status { get; set; }
    }
}
