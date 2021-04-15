namespace GameFinder.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameID = c.Int(nullable: false),
                        GameVisuals = c.Double(nullable: false),
                        GamePlay = c.Double(nullable: false),
                        OverallEnjoyment = c.Double(nullable: false),
                        GameUI = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameID, cascadeDelete: true)
                .Index(t => t.GameID);
            
            AddColumn("dbo.Games", "MaturityRating", c => c.String());
            AlterColumn("dbo.Games", "GameGenre", c => c.String());
            DropColumn("dbo.Games", "MatRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "MatRating", c => c.Int(nullable: false));
            DropForeignKey("dbo.Ratings", "GameID", "dbo.Games");
            DropIndex("dbo.Ratings", new[] { "GameID" });
            AlterColumn("dbo.Games", "GameGenre", c => c.Int(nullable: false));
            DropColumn("dbo.Games", "MaturityRating");
            DropTable("dbo.Ratings");
        }
    }
}
