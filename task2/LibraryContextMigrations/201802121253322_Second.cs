namespace task2.LibraryContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(maxLength: 100),
                        Brochure_BrochureId = c.Int(),
                        Journal_JournalId = c.Int(),
                    })
                .PrimaryKey(t => t.AuthorId)
                .ForeignKey("dbo.Brochures", t => t.Brochure_BrochureId)
                .ForeignKey("dbo.Journals", t => t.Journal_JournalId)
                .Index(t => t.Brochure_BrochureId)
                .Index(t => t.Journal_JournalId);
            
            CreateTable(
                "dbo.AuthorBooks",
                c => new
                    {
                        Author_AuthorId = c.Int(nullable: false),
                        Book_BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Author_AuthorId, t.Book_BookId })
                .ForeignKey("dbo.Authors", t => t.Author_AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookId, cascadeDelete: true)
                .Index(t => t.Author_AuthorId)
                .Index(t => t.Book_BookId);
            
            DropColumn("dbo.Books", "Authors");
            DropColumn("dbo.Brochures", "Authors");
            DropColumn("dbo.Journals", "Authors");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Journals", "Authors", c => c.String());
            AddColumn("dbo.Brochures", "Authors", c => c.String());
            AddColumn("dbo.Books", "Authors", c => c.String());
            DropForeignKey("dbo.Authors", "Journal_JournalId", "dbo.Journals");
            DropForeignKey("dbo.Authors", "Brochure_BrochureId", "dbo.Brochures");
            DropForeignKey("dbo.AuthorBooks", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.AuthorBooks", "Author_AuthorId", "dbo.Authors");
            DropIndex("dbo.AuthorBooks", new[] { "Book_BookId" });
            DropIndex("dbo.AuthorBooks", new[] { "Author_AuthorId" });
            DropIndex("dbo.Authors", new[] { "Journal_JournalId" });
            DropIndex("dbo.Authors", new[] { "Brochure_BrochureId" });
            DropTable("dbo.AuthorBooks");
            DropTable("dbo.Authors");
        }
    }
}
