namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategory", "ProductType", c => c.Int(nullable: false));
            DropColumn("dbo.ProductCategory", "type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductCategory", "type", c => c.Int(nullable: false));
            DropColumn("dbo.ProductCategory", "ProductType");
        }
    }
}
