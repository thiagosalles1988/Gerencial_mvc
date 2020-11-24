namespace Gerencial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DebitoMigrationRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Debits", "PaymentsDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Debits", "PaymentsDate", c => c.DateTime());
            AlterColumn("dbo.Clients", "BirthDate", c => c.DateTime());
        }
    }
}
