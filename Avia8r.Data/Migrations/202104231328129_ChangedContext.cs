namespace Avia8r.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FlightLeg", "AcTail", "dbo.Aircraft");
            DropForeignKey("dbo.MxEvent", "AcTail", "dbo.Aircraft");
            DropIndex("dbo.FlightLeg", new[] { "AcTail" });
            DropIndex("dbo.MxEvent", new[] { "AcTail" });
            DropPrimaryKey("dbo.Aircraft");
            AlterColumn("dbo.Aircraft", "AcTail", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.FlightLeg", "AcTail", c => c.String(maxLength: 128));
            AlterColumn("dbo.MxEvent", "AcTail", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Aircraft", "AcTail");
            CreateIndex("dbo.FlightLeg", "AcTail");
            CreateIndex("dbo.MxEvent", "AcTail");
            AddForeignKey("dbo.FlightLeg", "AcTail", "dbo.Aircraft", "AcTail");
            AddForeignKey("dbo.MxEvent", "AcTail", "dbo.Aircraft", "AcTail");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MxEvent", "AcTail", "dbo.Aircraft");
            DropForeignKey("dbo.FlightLeg", "AcTail", "dbo.Aircraft");
            DropIndex("dbo.MxEvent", new[] { "AcTail" });
            DropIndex("dbo.FlightLeg", new[] { "AcTail" });
            DropPrimaryKey("dbo.Aircraft");
            AlterColumn("dbo.MxEvent", "AcTail", c => c.Guid(nullable: false));
            AlterColumn("dbo.FlightLeg", "AcTail", c => c.Guid(nullable: false));
            AlterColumn("dbo.Aircraft", "AcTail", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Aircraft", "AcTail");
            CreateIndex("dbo.MxEvent", "AcTail");
            CreateIndex("dbo.FlightLeg", "AcTail");
            AddForeignKey("dbo.MxEvent", "AcTail", "dbo.Aircraft", "AcTail", cascadeDelete: true);
            AddForeignKey("dbo.FlightLeg", "AcTail", "dbo.Aircraft", "AcTail", cascadeDelete: true);
        }
    }
}
