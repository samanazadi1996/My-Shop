namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Product", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "brandId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "brandId");
            AddForeignKey("dbo.Product", "brandId", "dbo.Brand", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "brandId", "dbo.Brand");
            DropIndex("dbo.Product", new[] { "brandId" });
            DropColumn("dbo.Product", "brandId");
            DropColumn("dbo.Product", "Status");
            DropTable("dbo.Brand");
        }
    }
}
