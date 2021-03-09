namespace WalkingDead.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedforeignkeys : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Character", name: "EpisodeId", newName: "FirstEpisodeId");
            RenameIndex(table: "dbo.Character", name: "IX_EpisodeId", newName: "IX_FirstEpisodeId");
            AddColumn("dbo.Character", "LastEpisodeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Character", "LastEpisodeId");
            AddForeignKey("dbo.Character", "LastEpisodeId", "dbo.Episode", "EpisodeId", cascadeDelete: false);
            DropColumn("dbo.Character", "Features");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Character", "Features", c => c.String());
            DropForeignKey("dbo.Character", "LastEpisodeId", "dbo.Episode");
            DropIndex("dbo.Character", new[] { "LastEpisodeId" });
            DropColumn("dbo.Character", "LastEpisodeId");
            RenameIndex(table: "dbo.Character", name: "IX_FirstEpisodeId", newName: "IX_EpisodeId");
            RenameColumn(table: "dbo.Character", name: "FirstEpisodeId", newName: "EpisodeId");
        }
    }
}
