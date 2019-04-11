namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditEvent_02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "EventDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Event", "EventDescription");
        }
    }
}
