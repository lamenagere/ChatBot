namespace ChatBot.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changement_ConversationId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activities", "Conversation_Id", "dbo.Conversations");
            DropIndex("dbo.Activities", new[] { "Conversation_Id" });
            RenameColumn(table: "dbo.Activities", name: "Conversation_Id", newName: "Conversation_ConversationId");
            DropPrimaryKey("dbo.Conversations");
            AddColumn("dbo.Conversations", "ConversationId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Activities", "Conversation_ConversationId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Conversations", "ConversationId");
            CreateIndex("dbo.Activities", "Conversation_ConversationId");
            AddForeignKey("dbo.Activities", "Conversation_ConversationId", "dbo.Conversations", "ConversationId");
            DropColumn("dbo.Conversations", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Conversations", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Activities", "Conversation_ConversationId", "dbo.Conversations");
            DropIndex("dbo.Activities", new[] { "Conversation_ConversationId" });
            DropPrimaryKey("dbo.Conversations");
            AlterColumn("dbo.Activities", "Conversation_ConversationId", c => c.Int());
            DropColumn("dbo.Conversations", "ConversationId");
            AddPrimaryKey("dbo.Conversations", "Id");
            RenameColumn(table: "dbo.Activities", name: "Conversation_ConversationId", newName: "Conversation_Id");
            CreateIndex("dbo.Activities", "Conversation_Id");
            AddForeignKey("dbo.Activities", "Conversation_Id", "dbo.Conversations", "Id");
        }
    }
}
