namespace ChatRoom.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addforegineproperies2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "UserId");
            DropColumn("dbo.Users", "MessagesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "MessagesId", c => c.String());
            AddColumn("dbo.Messages", "UserId", c => c.String());
        }
    }
}
