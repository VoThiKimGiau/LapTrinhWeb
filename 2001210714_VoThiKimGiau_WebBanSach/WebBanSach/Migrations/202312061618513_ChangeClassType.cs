namespace WebBanSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeClassType : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Types", newName: "TypeBs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TypeBs", newName: "Types");
        }
    }
}
