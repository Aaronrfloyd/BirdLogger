namespace BirdLogger.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoggerId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logger", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logger", "ModifiedUtc");
        }
    }
}
