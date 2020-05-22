namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Value", "Description", c => c.String());
            DropColumn("dbo.Value", "type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Value", "type", c => c.String());
            DropColumn("dbo.Value", "Description");
        }
    }
}
