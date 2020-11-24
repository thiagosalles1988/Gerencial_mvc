namespace Gerencial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditMigrationName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Credits", "NameCredit", c => c.String(nullable: false));
            DropColumn("dbo.Credits", "NameDebit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Credits", "NameDebit", c => c.String(nullable: false));
            DropColumn("dbo.Credits", "NameCredit");
        }
    }
}
