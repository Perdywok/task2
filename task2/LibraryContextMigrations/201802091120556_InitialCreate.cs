namespace task2.LibraryContextMigrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        Pages = c.Int(nullable: false),
                        Content = c.String(),
                        Genre = c.Int(nullable: false),
                        Authors = c.String(),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.Brochures",
                c => new
                    {
                        BrochureId = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        Pages = c.Int(nullable: false),
                        Content = c.String(),
                        Genre = c.Int(nullable: false),
                        Authors = c.String(),
                    })
                .PrimaryKey(t => t.BrochureId);
            
            CreateTable(
                "dbo.Journals",
                c => new
                    {
                        JournalId = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        Pages = c.Int(nullable: false),
                        Content = c.String(),
                        Genre = c.Int(nullable: false),
                        Authors = c.String(),
                    })
                .PrimaryKey(t => t.JournalId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Journals");
            DropTable("dbo.Brochures");
            DropTable("dbo.Books");
        }
    }
}
