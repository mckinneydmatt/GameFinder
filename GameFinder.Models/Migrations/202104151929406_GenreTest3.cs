namespace GameFinder.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreTest3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Genres", "ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Genres", "GameGenreId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Genres", "GameGenreId");
            CreateIndex("dbo.Genres", "ID");
            AddForeignKey("dbo.Genres", "ID", "dbo.Game", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Genres", "ID", "dbo.Game");
            DropIndex("dbo.Genres", new[] { "ID" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Genres", "GameGenreId", c => c.Int(nullable: false));
            AlterColumn("dbo.Genres", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Genres", "ID");
        }
    }
}
