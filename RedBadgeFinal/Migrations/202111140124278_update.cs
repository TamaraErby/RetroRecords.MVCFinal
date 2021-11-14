namespace RedBadgeFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "City", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "State", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "ZipCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ZipCode");
            DropColumn("dbo.Customers", "State");
            DropColumn("dbo.Customers", "City");
        }
    }
}
