namespace WalkingDead.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Location", "FirstEpisodeId", "dbo.Episode");
            DropForeignKey("dbo.Location", "LastEpisodeId", "dbo.Episode");
            DropIndex("dbo.Location", new[] { "FirstEpisodeId" });
            DropIndex("dbo.Location", new[] { "LastEpisodeId" });
            AlterColumn("dbo.Location", "FirstEpisodeId", c => c.Int());
            AlterColumn("dbo.Location", "LastEpisodeId", c => c.Int());
            CreateIndex("dbo.Location", "FirstEpisodeId");
            CreateIndex("dbo.Location", "LastEpisodeId");
            AddForeignKey("dbo.Location", "FirstEpisodeId", "dbo.Episode", "EpisodeId");
            AddForeignKey("dbo.Location", "LastEpisodeId", "dbo.Episode", "EpisodeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Location", "LastEpisodeId", "dbo.Episode");
            DropForeignKey("dbo.Location", "FirstEpisodeId", "dbo.Episode");
            DropIndex("dbo.Location", new[] { "LastEpisodeId" });
            DropIndex("dbo.Location", new[] { "FirstEpisodeId" });
            AlterColumn("dbo.Location", "LastEpisodeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Location", "FirstEpisodeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Location", "LastEpisodeId");
            CreateIndex("dbo.Location", "FirstEpisodeId");
            AddForeignKey("dbo.Location", "LastEpisodeId", "dbo.Episode", "EpisodeId", cascadeDelete: false);
            AddForeignKey("dbo.Location", "FirstEpisodeId", "dbo.Episode", "EpisodeId", cascadeDelete: false);
        }
    }
}
