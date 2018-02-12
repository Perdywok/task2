using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace task2.Models
{
    public class Journal
    {
        public Journal()
        {

        }
        [Required]
        public int JournalId { get; set; }

        [Display(Name = "Journal Name")]
        [MaxLength(100, ErrorMessage = "Journal Name must be 100 characters or less"), MinLength(5)]

        public string BookName { get; set; }

        public int Pages { get; set; }

        public string Content { get; set; }

        public Genre Genre { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}