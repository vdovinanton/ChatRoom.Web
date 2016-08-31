namespace ChatRoom.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addforegineproperies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "UserId", c => c.String());
            AddColumn("dbo.Users", "MessagesId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "MessagesId");
            DropColumn("dbo.Messages", "UserId");
        }
    }
}
