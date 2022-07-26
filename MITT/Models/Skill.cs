using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MITT.Models
{
    [Table("skill")]
    public class Skill
    {
        [Key]
        public int skillId { get; set; }
        public string skillName { get; set; }

    }
}
