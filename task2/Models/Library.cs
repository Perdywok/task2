namespace task2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Library : DbContext
    {
        public Library()
            : base("name=Library")
        {
        }
        public DbSet<Book> Books  { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Brochure> Brochures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

    }
}
