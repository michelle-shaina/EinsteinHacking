using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EinsteinHacking.Models
{
    [Table("Challenges", Schema = "mod")]
    public class Challenge: BaseModel
    {
        [Key]
        public int ChallengeID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int PointsOnCompletion { get; set; }
        public int PointsRemovedPerHintUsed { get; set; }
        public string LinkToexplanationVideo { get; set; }
        public List<Hint> Hints { get; set; }

        public bool IsValid =>  !String.IsNullOrEmpty(Name)
                    && !String.IsNullOrEmpty(Name)
                    && PointsOnCompletion > 0
                    && PointsRemovedPerHintUsed > 0;
        

    }
}
