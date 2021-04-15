namespace GameFinder.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreTest7 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Genres", name: "ID", newName: "GameID");
            RenameIndex(table: "dbo.Genres", name: "IX_ID", newName: "IX_GameID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Genres", name: "IX_GameID", newName: "IX_ID");
            RenameColumn(table: "dbo.Genres", name: "GameID", newName: "ID");
        }
    }
}
