namespace Gighub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMessageColumnOnNotificationsTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Notifications", "Message");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "Message", c => c.String());
        }
    }
}
