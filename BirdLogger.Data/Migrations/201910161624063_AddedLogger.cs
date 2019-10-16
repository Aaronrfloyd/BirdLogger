namespace BirdLogger.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLogger : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logger", "CreatedUtc", c => c.DateTime(nullable: false));
            DropColumn("dbo.Logger", "ModifiedUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logger", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Logger", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
