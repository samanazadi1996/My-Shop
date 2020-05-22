namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Newsletters", c => c.Boolean(nullable: false));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false));
            DropColumn("dbo.User", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Age", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "Email", c => c.String());
            DropColumn("dbo.User", "Newsletters");
        }
    }
}
