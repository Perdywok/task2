namespace task2.LibraryContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "BookName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Brochures", "BookName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Journals", "BookName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Journals", "BookName", c => c.String());
            AlterColumn("dbo.Brochures", "BookName", c => c.String());
            AlterColumn("dbo.Books", "BookName", c => c.String());
        }
    }
}
