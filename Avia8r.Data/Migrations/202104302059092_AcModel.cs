namespace Avia8r.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AcModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aircraft", "AcModel", c => c.String(nullable: false));
            DropColumn("dbo.Aircraft", "Model");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aircraft", "Model", c => c.String(nullable: false));
            DropColumn("dbo.Aircraft", "AcModel");
        }
    }
}
