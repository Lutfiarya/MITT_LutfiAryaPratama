using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MITT.Models
{
    [Table("userprofile")]
    public class UserProfile
    {
        [Key]   
        public int userProfileId { get; set; } 
        public string username { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public DateTime bod { get; set; }

        public string email { get; set; }

    }
}
