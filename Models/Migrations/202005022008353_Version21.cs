namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Caption", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Caption");
        }
    }
}
