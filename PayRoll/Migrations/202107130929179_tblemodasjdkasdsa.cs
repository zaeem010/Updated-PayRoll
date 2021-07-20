namespace PayRoll.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblemodasjdkasdsa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Type");
        }
    }
}
