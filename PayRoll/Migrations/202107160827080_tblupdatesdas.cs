namespace PayRoll.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblupdatesdas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestdayUpdates",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Restday = c.String(),
                        Date = c.DateTime(nullable: false),
                        EmpCode = c.String(),
                        Comid = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.RoasterUpdates",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Roasterid = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        EmpCode = c.String(),
                        Comid = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RoasterUpdates");
            DropTable("dbo.RestdayUpdates");
        }
    }
}
