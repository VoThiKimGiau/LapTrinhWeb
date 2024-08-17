namespace WebBanSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(),
                    })
                .PrimaryKey(t => t.AuthorID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Detail = c.String(),
                        NO_Goods = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        AuthorID = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Types", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.TypeID)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.TypeID);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        ProId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Book_BookID = c.Int(),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.Books", t => t.Book_BookID)
                .Index(t => t.Book_BookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "Book_BookID", "dbo.Books");
            DropForeignKey("dbo.Books", "TypeID", "dbo.Types");
            DropForeignKey("dbo.Books", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Carts", new[] { "Book_BookID" });
            DropIndex("dbo.Books", new[] { "AuthorID" });
            DropIndex("dbo.Books", new[] { "TypeID" });
            DropTable("dbo.Carts");
            DropTable("dbo.Types");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
