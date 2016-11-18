namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Position", c => c.String());
            AddColumn("dbo.User", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Discriminator");
            DropColumn("dbo.User", "Position");
        }
    }
}
