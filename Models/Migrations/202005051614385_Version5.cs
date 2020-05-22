namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Address", "userId", "dbo.User");
            AddColumn("dbo.User", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.User", "Roles", c => c.String());
            AlterColumn("dbo.Address", "Province", c => c.String(nullable: false));
            AlterColumn("dbo.Address", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Address", "FullAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Address", "PostalCode", c => c.String(nullable: false));
            AddForeignKey("dbo.Address", "userId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "userId", "dbo.User");
            AlterColumn("dbo.Address", "PostalCode", c => c.String());
            AlterColumn("dbo.Address", "FullAddress", c => c.String());
            AlterColumn("dbo.Address", "City", c => c.String());
            AlterColumn("dbo.Address", "Province", c => c.String());
            DropColumn("dbo.User", "Roles");
            DropColumn("dbo.User", "DateOfBirth");
            AddForeignKey("dbo.Address", "userId", "dbo.User", "Id", cascadeDelete: true);
        }
    }
}
