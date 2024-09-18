using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AquaGuide.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string Text { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }


        public virtual List<Comment> Comments { get; set; }
    }
}
