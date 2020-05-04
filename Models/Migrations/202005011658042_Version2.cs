namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Firstname", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.User", "Lastname", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.User", "Phonenumber", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Password", c => c.String());
            AlterColumn("dbo.User", "Phonenumber", c => c.String());
            AlterColumn("dbo.User", "Lastname", c => c.String());
            AlterColumn("dbo.User", "Firstname", c => c.String());
        }
    }
}
