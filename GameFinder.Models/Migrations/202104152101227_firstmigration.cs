namespace GameFinder.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GameGenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                        GameID = c.Int(nullable: false),
                        GameTitle = c.String(),
                    })
                .PrimaryKey(t => t.GameGenreId)
                .ForeignKey("dbo.Games", t => t.GameID, cascadeDelete: true)
                .Index(t => t.GameID);
            
            AddColumn("dbo.Games", "IsSinglePlayer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Games", "GameGenreId", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "GenreName", c => c.String());
            AddColumn("dbo.Games", "Game_ID", c => c.Int());
            CreateIndex("dbo.Games", "Game_ID");
            AddForeignKey("dbo.Games", "Game_ID", "dbo.Games", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Genres", "GameID", "dbo.Games");
            DropForeignKey("dbo.Games", "Game_ID", "dbo.Games");
            DropIndex("dbo.Genres", new[] { "GameID" });
            DropIndex("dbo.Games", new[] { "Game_ID" });
            DropColumn("dbo.Games", "Game_ID");
            DropColumn("dbo.Games", "GenreName");
            DropColumn("dbo.Games", "GameGenreId");
            DropColumn("dbo.Games", "IsSinglePlayer");
            DropTable("dbo.Genres");
        }
    }
}
