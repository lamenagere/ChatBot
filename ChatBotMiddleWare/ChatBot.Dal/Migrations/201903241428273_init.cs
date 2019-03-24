namespace ChatBot.Dal.Migrations
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
                        Id = c.String(nullable: false, maxLength: 128),
                        Type = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        ChannelId = c.String(),
                        Text = c.String(),
                        InputHint = c.String(),
                        ReplyToId = c.String(),
                        Conversation_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conversations", t => t.Conversation_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Conversation_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Conversations", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Activities", "Conversation_Id", "dbo.Conversations");
            DropIndex("dbo.Conversations", new[] { "User_Id" });
            DropIndex("dbo.Activities", new[] { "User_Id" });
            DropIndex("dbo.Activities", new[] { "Conversation_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Conversations");
            DropTable("dbo.Activities");
        }
    }
}
