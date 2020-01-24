namespace Amh.LibraryMan.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 256),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AuthorId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                        Edition = c.Int(nullable: false),
                        PublishDate = c.Int(nullable: false),
                        SerialNumber = c.String(nullable: false, maxLength: 16),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Address = c.String(maxLength: 512),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "PublisherId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.Publishers");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
