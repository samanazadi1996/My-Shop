namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Datetime = c.DateTime(nullable: false),
                        rate = c.Int(),
                        userId = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.productId)
                .ForeignKey("dbo.User", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Discount = c.Int(nullable: false),
                        Datetime = c.DateTime(nullable: false),
                        userId = c.Int(nullable: false),
                        groupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Group", t => t.groupId)
                .ForeignKey("dbo.User", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.groupId);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        targetId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Count = c.Int(nullable: false),
                        Datetime = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        status = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.productId)
                .ForeignKey("dbo.User", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        Phonenumber = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Status = c.String(),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.userId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Datetime = c.DateTime(nullable: false),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.userId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.ProductFile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationFile = c.String(),
                        productId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.productId)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.Value",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "userId", "dbo.User");
            DropForeignKey("dbo.Comment", "productId", "dbo.Product");
            DropForeignKey("dbo.Product", "userId", "dbo.User");
            DropForeignKey("dbo.ProductFile", "productId", "dbo.Product");
            DropForeignKey("dbo.Order", "userId", "dbo.User");
            DropForeignKey("dbo.Ticket", "userId", "dbo.User");
            DropForeignKey("dbo.Sms", "userId", "dbo.User");
            DropForeignKey("dbo.Order", "productId", "dbo.Product");
            DropForeignKey("dbo.Product", "groupId", "dbo.Group");
            DropIndex("dbo.ProductFile", new[] { "productId" });
            DropIndex("dbo.Ticket", new[] { "userId" });
            DropIndex("dbo.Sms", new[] { "userId" });
            DropIndex("dbo.Order", new[] { "productId" });
            DropIndex("dbo.Order", new[] { "userId" });
            DropIndex("dbo.Product", new[] { "groupId" });
            DropIndex("dbo.Product", new[] { "userId" });
            DropIndex("dbo.Comment", new[] { "productId" });
            DropIndex("dbo.Comment", new[] { "userId" });
            DropTable("dbo.Value");
            DropTable("dbo.ProductFile");
            DropTable("dbo.Ticket");
            DropTable("dbo.Sms");
            DropTable("dbo.User");
            DropTable("dbo.Order");
            DropTable("dbo.Group");
            DropTable("dbo.Product");
            DropTable("dbo.Comment");
        }
    }
}
