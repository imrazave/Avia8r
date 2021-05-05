namespace Avia8r.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MxEventAndFlightLegUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MxEvent", "HoursOutOfService", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MxEvent", "HoursOutOfService");
        }
    }
}
