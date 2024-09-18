using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AquaGuide.Entities
{
    public class Fish
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Species { get; set; }

        [Required]
        public string Attitude { get; set; }

        [Required]
        public string Feeding { get; set; }

        [Required]
        public int Amount { get; set; }

        [Display(Name = "IdentityUser")]
        public virtual string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser IdentityUsers { get; set; }

        public virtual Fish Fishes { get; set; }
    }
}
