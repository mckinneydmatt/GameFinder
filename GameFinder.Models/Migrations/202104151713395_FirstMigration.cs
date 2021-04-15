namespace GameFinder.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GameGenreId = c.Int(nullable: false),
                        GenreName = c.String(),
                        GameTitle = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Games", "GameGenreId", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "GenreName", c => c.String());
            DropColumn("dbo.Games", "GameGenre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "GameGenre", c => c.Int(nullable: false));
            DropColumn("dbo.Games", "GenreName");
            DropColumn("dbo.Games", "GameGenreId");
            DropTable("dbo.Genres");
        }
    }
}
