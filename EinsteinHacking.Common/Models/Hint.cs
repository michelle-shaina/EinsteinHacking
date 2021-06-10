using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EinsteinHacking.Models
{
    [Table("Hint", Schema = "mod")]
    public class Hint : BaseModel
    {
        [Key]
        public int HintID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsValid => !String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Description);
        
    }
}
