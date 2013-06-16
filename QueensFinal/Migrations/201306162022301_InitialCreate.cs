namespace QueensFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Competitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        StartDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Competitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BroughtForwardPoints = c.Int(nullable: false),
                        BroughtForwardVs = c.Int(nullable: false),
                        x900Sighter1 = c.Int(nullable: false),
                        x900Sighter2 = c.Int(nullable: false),
                        x900Sighter1Converted = c.Boolean(nullable: false),
                        x900Sighter2Converted = c.Boolean(nullable: false),
                        x900Shot1 = c.Int(nullable: false),
                        x900Shot2 = c.Int(nullable: false),
                        x900Shot3 = c.Int(nullable: false),
                        x900Shot4 = c.Int(nullable: false),
                        x900Shot5 = c.Int(nullable: false),
                        x900Shot6 = c.Int(nullable: false),
                        x900Shot7 = c.Int(nullable: false),
                        x900Shot8 = c.Int(nullable: false),
                        x900Shot9 = c.Int(nullable: false),
                        x900Shot10 = c.Int(nullable: false),
                        x900Shot11 = c.Int(nullable: false),
                        x900Shot12 = c.Int(nullable: false),
                        x900Shot13 = c.Int(nullable: false),
                        x900Shot14 = c.Int(nullable: false),
                        x900Shot15 = c.Int(nullable: false),
                        x1000Sighter1 = c.Int(nullable: false),
                        x1000Sighter2 = c.Int(nullable: false),
                        x1000Sighter1Converted = c.Boolean(nullable: false),
                        x1000Sighter2Converted = c.Boolean(nullable: false),
                        x1000Shot1 = c.Int(nullable: false),
                        x1000Shot2 = c.Int(nullable: false),
                        x1000Shot3 = c.Int(nullable: false),
                        x1000Shot4 = c.Int(nullable: false),
                        x1000Shot5 = c.Int(nullable: false),
                        x1000Shot6 = c.Int(nullable: false),
                        x1000Shot7 = c.Int(nullable: false),
                        x1000Shot8 = c.Int(nullable: false),
                        x1000Shot9 = c.Int(nullable: false),
                        x1000Shot10 = c.Int(nullable: false),
                        x1000Shot11 = c.Int(nullable: false),
                        x1000Shot12 = c.Int(nullable: false),
                        x1000Shot13 = c.Int(nullable: false),
                        x1000Shot14 = c.Int(nullable: false),
                        x1000Shot15 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Competitors");
            DropTable("dbo.Competitions");
        }
    }
}
