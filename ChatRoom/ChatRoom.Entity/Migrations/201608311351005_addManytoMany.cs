namespace ChatRoom.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addManytoMany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserMessages",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Message_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Message_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Messages", t => t.Message_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Message_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMessages", "Message_Id", "dbo.Messages");
            DropForeignKey("dbo.UserMessages", "User_Id", "dbo.Users");
            DropIndex("dbo.UserMessages", new[] { "Message_Id" });
            DropIndex("dbo.UserMessages", new[] { "User_Id" });
            DropTable("dbo.UserMessages");
            DropTable("dbo.Users");
            DropTable("dbo.Messages");
        }
    }
}
