namespace BirdLogger.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nestspls : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nest",
                c => new
                    {
                        NestId = c.Int(nullable: false, identity: true),
                        LoggerId = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        Site = c.String(),
                        Materials = c.String(),
                        Altitude = c.String(),
                        Eggs = c.Int(nullable: false),
                        Hatchlings = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.NestId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Nest");
        }
    }
}
