namespace PharmacySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineID = c.Int(nullable: false, identity: true),
                        MedicineName = c.String(),
                        NumberAvailable = c.Int(nullable: false),
                        MedicinegroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicineID)
                .ForeignKey("dbo.MedicineGroups", t => t.MedicinegroupID, cascadeDelete: true)
                .Index(t => t.MedicinegroupID);
            
            CreateTable(
                "dbo.MedicineGroups",
                c => new
                    {
                        MedicineGroupID = c.Int(nullable: false, identity: true),
                        MedicineGroupName = c.String(),
                    })
                .PrimaryKey(t => t.MedicineGroupID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        PatientName = c.String(),
                        PatientSurname = c.String(),
                        DateOfBirth = c.String(),
                        InsuranceNumber = c.String(),
                    })
                .PrimaryKey(t => t.PatientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicines", "MedicinegroupID", "dbo.MedicineGroups");
            DropIndex("dbo.Medicines", new[] { "MedicinegroupID" });
            DropTable("dbo.Patients");
            DropTable("dbo.MedicineGroups");
            DropTable("dbo.Medicines");
        }
    }
}
