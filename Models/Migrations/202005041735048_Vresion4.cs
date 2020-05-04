namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vresion4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Value", "Text", c => c.String());
            AddColumn("dbo.Value", "type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Value", "type");
            DropColumn("dbo.Value", "Text");
        }
    }
}
