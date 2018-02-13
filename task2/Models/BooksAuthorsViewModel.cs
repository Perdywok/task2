using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace task2.Models
{
    public class BooksAuthorsViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Author> AllAuthors { get; set; }

        private List<int> _selectedAuthors;
        public List<int> SelectedAuthors
        {
            get
            {
                if (_selectedAuthors == null)
                {
                    _selectedAuthors = Book.Authors.Select(m => m.AuthorId).ToList();
                }
                return _selectedAuthors;
            }
            set { _selectedAuthors = value; }
        }
    }
}