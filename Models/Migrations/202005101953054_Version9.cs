namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "TermsAndConditions", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "TermsAndConditions");
        }
    }
}
