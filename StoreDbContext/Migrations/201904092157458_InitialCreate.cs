namespace StoreDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        CountryCode = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        Apartment = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Artnum = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrdersToArticles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .Index(t => t.OrderId)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OxId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        AddressId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        InvoiceNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .ForeignKey("dbo.OrderStates", t => t.StateId)
                .Index(t => t.AddressId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.OrderStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdersToArticles", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "StateId", "dbo.OrderStates");
            DropForeignKey("dbo.Orders", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.OrdersToArticles", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Addresses", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "StateId" });
            DropIndex("dbo.Orders", new[] { "AddressId" });
            DropIndex("dbo.OrdersToArticles", new[] { "ArticleId" });
            DropIndex("dbo.OrdersToArticles", new[] { "OrderId" });
            DropIndex("dbo.Addresses", new[] { "CustomerId" });
            DropTable("dbo.OrderStates");
            DropTable("dbo.Orders");
            DropTable("dbo.OrdersToArticles");
            DropTable("dbo.Articles");
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
