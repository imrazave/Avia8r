namespace Avia8r.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migratingAvia8r : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aircraft",
                c => new
                    {
                        AcTail = c.Guid(nullable: false),
                        Model = c.String(nullable: false),
                        Manufacturer = c.String(nullable: false),
                        Airline = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AcTail);
            
            CreateTable(
                "dbo.FlightLeg",
                c => new
                    {
                        TripId = c.Int(nullable: false, identity: true),
                        OriginAirport = c.String(nullable: false),
                        DestinationAirport = c.String(nullable: false),
                        DepartureDate = c.DateTime(nullable: false),
                        AcTail = c.Guid(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TripId)
                .ForeignKey("dbo.Aircraft", t => t.AcTail, cascadeDelete: true)
                .Index(t => t.AcTail);
            
            CreateTable(
                "dbo.MxEvent",
                c => new
                    {
                        MxId = c.Int(nullable: false, identity: true),
                        AcTail = c.Guid(nullable: false),
                        TypeOfMx = c.Int(nullable: false),
                        MxDescription = c.String(nullable: false),
                        ManHours = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MxId)
                .ForeignKey("dbo.Aircraft", t => t.AcTail, cascadeDelete: true)
                .Index(t => t.AcTail);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.MxEvent", "AcTail", "dbo.Aircraft");
            DropForeignKey("dbo.FlightLeg", "AcTail", "dbo.Aircraft");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.MxEvent", new[] { "AcTail" });
            DropIndex("dbo.FlightLeg", new[] { "AcTail" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.MxEvent");
            DropTable("dbo.FlightLeg");
            DropTable("dbo.Aircraft");
        }
    }
}
