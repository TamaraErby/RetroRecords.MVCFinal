namespace RedBadgeFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vinyls", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Vinyls", "GenreId", "dbo.Genres");
            DropIndex("dbo.Vinyls", new[] { "GenreId" });
            DropIndex("dbo.Vinyls", new[] { "ArtistId" });
            RenameColumn(table: "dbo.Vinyls", name: "ArtistId", newName: "Artist_ArtistId");
            RenameColumn(table: "dbo.Vinyls", name: "GenreId", newName: "Genre_GenreId");
            AlterColumn("dbo.Vinyls", "Genre_GenreId", c => c.Int());
            AlterColumn("dbo.Vinyls", "Artist_ArtistId", c => c.Int());
            CreateIndex("dbo.Vinyls", "Artist_ArtistId");
            CreateIndex("dbo.Vinyls", "Genre_GenreId");
            AddForeignKey("dbo.Vinyls", "Artist_ArtistId", "dbo.Artists", "ArtistId");
            AddForeignKey("dbo.Vinyls", "Genre_GenreId", "dbo.Genres", "GenreId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vinyls", "Genre_GenreId", "dbo.Genres");
            DropForeignKey("dbo.Vinyls", "Artist_ArtistId", "dbo.Artists");
            DropIndex("dbo.Vinyls", new[] { "Genre_GenreId" });
            DropIndex("dbo.Vinyls", new[] { "Artist_ArtistId" });
            AlterColumn("dbo.Vinyls", "Artist_ArtistId", c => c.Int(nullable: false));
            AlterColumn("dbo.Vinyls", "Genre_GenreId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Vinyls", name: "Genre_GenreId", newName: "GenreId");
            RenameColumn(table: "dbo.Vinyls", name: "Artist_ArtistId", newName: "ArtistId");
            CreateIndex("dbo.Vinyls", "ArtistId");
            CreateIndex("dbo.Vinyls", "GenreId");
            AddForeignKey("dbo.Vinyls", "GenreId", "dbo.Genres", "GenreId", cascadeDelete: true);
            AddForeignKey("dbo.Vinyls", "ArtistId", "dbo.Artists", "ArtistId", cascadeDelete: true);
        }
    }
}
