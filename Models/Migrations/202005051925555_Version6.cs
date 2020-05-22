namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Keyword", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Keyword");
        }
    }
}
