using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EinsteinHacking.Models
{
    [Table("UserInformation", Schema = "mod")]
    public class UserInformation : BaseModel
    {
        [Key]
        public int UserInformationKey { get; set;}
        [Required]
        public IdentityUser User { get; set; }
        [Required]
        public List<UserProgress> Progress { get; set; }
    }
}
