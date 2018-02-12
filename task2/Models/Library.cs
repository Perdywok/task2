namespace task2.Models
{
    using System.Data.Entity;

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
