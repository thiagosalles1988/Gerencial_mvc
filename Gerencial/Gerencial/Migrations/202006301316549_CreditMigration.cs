namespace Gerencial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Credits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameDebit = c.String(nullable: false),
                        PaymentsDate = c.DateTime(nullable: false),
                        PaymentForm = c.String(),
                        Value = c.Single(nullable: false),
                        Observation = c.String(),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Credits", "ClientId", "dbo.Clients");
            DropIndex("dbo.Credits", new[] { "ClientId" });
            DropTable("dbo.Credits");
        }
    }
}
