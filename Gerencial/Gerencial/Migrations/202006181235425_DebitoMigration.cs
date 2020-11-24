namespace Gerencial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DebitoMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Debits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameDebit = c.String(nullable: false),
                        PaymentsDate = c.DateTime(),
                        PaymentForm = c.String(),
                        Value = c.String(nullable: false),
                        Observation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Debits");
        }
    }
}
