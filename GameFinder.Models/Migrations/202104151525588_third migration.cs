namespace GameFinder.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ratings", "GameVisuals", c => c.Int(nullable: false));
            AlterColumn("dbo.Ratings", "GamePlay", c => c.Int(nullable: false));
            AlterColumn("dbo.Ratings", "OverallEnjoyment", c => c.Int(nullable: false));
            AlterColumn("dbo.Ratings", "GameUI", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ratings", "GameUI", c => c.Double(nullable: false));
            AlterColumn("dbo.Ratings", "OverallEnjoyment", c => c.Double(nullable: false));
            AlterColumn("dbo.Ratings", "GamePlay", c => c.Double(nullable: false));
            AlterColumn("dbo.Ratings", "GameVisuals", c => c.Double(nullable: false));
        }
    }
}
