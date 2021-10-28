namespace RedBadgeFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vinyls",
                c => new
                    {
                        VinylId = c.Int(nullable: false, identity: true),
                        GenreId = c.Int(nullable: false),
                        ArtistId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.VinylId)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GenreId);
            
            AlterColumn("dbo.Artists", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vinyls", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Vinyls", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Vinyls", new[] { "ArtistId" });
            DropIndex("dbo.Vinyls", new[] { "GenreId" });
            AlterColumn("dbo.Artists", "Name", c => c.String());
            DropTable("dbo.Genres");
            DropTable("dbo.Vinyls");
        }
    }
}
