namespace GameFinder.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "IsSinglePlayer", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "IsSinglePlayer");
        }
    }
}
