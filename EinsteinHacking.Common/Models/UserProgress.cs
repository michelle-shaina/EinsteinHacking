using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EinsteinHacking.Models
{
    [Table("UserProgress", Schema = "mod")]
    public class UserProgress : BaseModel
    {
        [Key]
        public int UserProgressID { get; set; }
        public Challenge Challenge { get; set; }
        public Status Status { get; set; }
        public int HintsUsed { get; set; }

        public bool IsValid => Challenge != null;
    }
}
