using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AquaGuide.Entities
{
    public class Parameter
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        public int PH { get; set; }


        public int Type { get; set; }
        
        public int TDS { get; set; }

        public int KH { get; set; }

        public int GH { get; set; }

        public string Temperature { get; set; }

        public string Description { get; set; }

        public bool Share { get; set; }

        public Parameter()
        {
            Share = false;
        }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name= "IdentityUser")]
        public virtual string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser IdentityUsers { get; set; }

        public virtual Parameter Parameters { get; set; }
    }
}
