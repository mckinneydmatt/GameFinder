namespace GameFinder.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Games", "GameGenre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "GameGenre", c => c.String());
        }
    }
}
