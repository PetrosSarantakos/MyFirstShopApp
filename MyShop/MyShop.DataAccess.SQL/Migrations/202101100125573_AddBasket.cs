namespace MyShop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBasket : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BasketItems", "Quantity", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BasketItems", "Quantity", c => c.Int(nullable: false));
        }
    }
}
