namespace ChatRoom.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userKeytoString : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserMessages", "User_Id", "dbo.Users");
            DropIndex("dbo.UserMessages", new[] { "User_Id" });
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.UserMessages");
            AlterColumn("dbo.Users", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserMessages", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.UserMessages", new[] { "User_Id", "Message_Id" });
            CreateIndex("dbo.UserMessages", "User_Id");
            AddForeignKey("dbo.UserMessages", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMessages", "User_Id", "dbo.Users");
            DropIndex("dbo.UserMessages", new[] { "User_Id" });
            DropPrimaryKey("dbo.UserMessages");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.UserMessages", "User_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserMessages", new[] { "User_Id", "Message_Id" });
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.UserMessages", "User_Id");
            AddForeignKey("dbo.UserMessages", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
