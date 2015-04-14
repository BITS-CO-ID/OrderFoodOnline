namespace OrderFoodOnline.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pictureurl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meals", "PictureUrl", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meals", "PictureUrl");
        }
    }
}
