namespace EHI.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EHI_Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientContacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PatientContacts");
        }
    }
}
