namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        type = c.String(),
                        timestamp = c.DateTime(nullable: false),
                        channelId = c.String(),
                        conversationId = c.String(maxLength: 128),
                        text = c.String(),
                        replyToId = c.String(),
                        watermark = c.String(),
                        user_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.user_id)
                .ForeignKey("dbo.Conversations", t => t.conversationId)
                .Index(t => t.conversationId)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "conversationId", "dbo.Conversations");
            DropForeignKey("dbo.Activities", "user_id", "dbo.Users");
            DropIndex("dbo.Activities", new[] { "user_id" });
            DropIndex("dbo.Activities", new[] { "conversationId" });
            DropTable("dbo.Conversations");
            DropTable("dbo.Users");
            DropTable("dbo.Activities");
        }
    }
}
