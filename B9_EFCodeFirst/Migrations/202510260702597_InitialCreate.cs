namespace B9_EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DepID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.String(),
                        City = c.String(),
                        DepID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepID, cascadeDelete: true)
                .Index(t => t.DepID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DepID", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DepID" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
