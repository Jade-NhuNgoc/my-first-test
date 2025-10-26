namespace B9_EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnAge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Age", c => c.Int(nullable: false, defaultValue: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Age");
        }
    }
}
