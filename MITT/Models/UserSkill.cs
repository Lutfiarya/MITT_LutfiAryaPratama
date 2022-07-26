using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MITT.Models
{
    [Table("userskills")]
    public class UserSkill
    {
        [Key]
        public int userSkillId { get; set; }
        public string username { get; set; }
        public int skillId { get; set; }
        public int skillLevelId { get; set; }

    }
}
