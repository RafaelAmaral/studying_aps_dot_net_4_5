namespace StudingEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnotherModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnotherModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Field = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AnotherModels");
        }
    }
}
