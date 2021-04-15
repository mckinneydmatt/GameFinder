namespace GameFinder.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Game_ID", c => c.Int());
            CreateIndex("dbo.Games", "Game_ID");
            AddForeignKey("dbo.Games", "Game_ID", "dbo.Games", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "Game_ID", "dbo.Games");
            DropIndex("dbo.Games", new[] { "Game_ID" });
            DropColumn("dbo.Games", "Game_ID");
        }
    }
}
