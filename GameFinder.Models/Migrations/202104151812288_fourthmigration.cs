namespace GameFinder.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourthmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "GameGenre", c => c.String(nullable: false, defaultValue : "VideoGame"));
            AlterColumn("dbo.Games", "MaturityRating", c => c.String(nullable: false, defaultValue : "Unrated"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "MaturityRating", c => c.String());
            AlterColumn("dbo.Games", "GameGenre", c => c.String());
        }
    }
}
