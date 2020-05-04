namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vresion3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Province = c.String(),
                        City = c.String(),
                        FullAddress = c.String(),
                        PostalCode = c.String(),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "userId", "dbo.User");
            DropIndex("dbo.Address", new[] { "userId" });
            DropTable("dbo.Address");
        }
    }
}
