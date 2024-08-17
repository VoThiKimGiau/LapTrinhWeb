namespace WebBanSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Book_BookID", "dbo.Books");
            DropIndex("dbo.Carts", new[] { "Book_BookID" });
            AlterColumn("dbo.Carts", "Book_BookID", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "Book_BookID");
            AddForeignKey("dbo.Carts", "Book_BookID", "dbo.Books", "BookID", cascadeDelete: true);
            DropColumn("dbo.Carts", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "UserID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Carts", "Book_BookID", "dbo.Books");
            DropIndex("dbo.Carts", new[] { "Book_BookID" });
            AlterColumn("dbo.Carts", "Book_BookID", c => c.Int());
            CreateIndex("dbo.Carts", "Book_BookID");
            AddForeignKey("dbo.Carts", "Book_BookID", "dbo.Books", "BookID");
        }
    }
}
