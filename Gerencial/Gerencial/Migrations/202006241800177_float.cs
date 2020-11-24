namespace Gerencial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _float : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Debits", "Value", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Debits", "Value", c => c.String(nullable: false));
        }
    }
}
