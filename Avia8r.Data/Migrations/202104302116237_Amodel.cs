namespace Avia8r.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Amodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aircraft", "AModel", c => c.String(nullable: false));
            DropColumn("dbo.Aircraft", "AcModel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aircraft", "AcModel", c => c.String(nullable: false));
            DropColumn("dbo.Aircraft", "AModel");
        }
    }
}
