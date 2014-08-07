namespace Betonirai.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Item = c.String(),
                        Quantity = c.Double(nullable: false),
                        Measure = c.Int(nullable: false),
                        Comment = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        DeliveryDate = c.DateTime(),
                        DeliveryTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
