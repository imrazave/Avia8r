namespace Avia8r.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AcModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aircraft", "AcModel", c => c.String(nullable: false));
            DropColumn("dbo.Aircraft", "AModel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aircraft", "AModel", c => c.String(nullable: false));
            DropColumn("dbo.Aircraft", "AcModel");
        }
    }
}
