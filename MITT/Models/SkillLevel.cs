using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MITT.Models
{
    [Table("silllevel")]
    public class SkillLevel
    {
        [Key]
        public int skillLevelId { get; set; }
        public string skillLevelName { get; set; }

    }
}
