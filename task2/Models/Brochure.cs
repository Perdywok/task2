using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace task2.Models
{
    public class Brochure 
    {
        public Brochure()
        {

        }
        [Required]      
        public int BrochureId { get; set; }

        [Display(Name = "Brochure Name")]
        [MaxLength(100, ErrorMessage = "Brochure Name must be 100 characters or less"), MinLength(5)]
        public string BookName { get; set; }

        public int Pages { get; set; }

        public string Content { get; set; }

        public Genre Genre { get; set; }

        public string Authors { get; set; }
    }
}