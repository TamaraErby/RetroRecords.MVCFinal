namespace RedBadgeFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "Category", c => c.String(nullable: false));
            DropColumn("dbo.Genres", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Genres", "Category");
        }
    }
}
