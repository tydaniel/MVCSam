namespace MVCSam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerBithday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthday", c => c.DateTime());
            Sql("UPDATE Customers SET Birthday='1982-09-01' WHERE Id=1");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Birthday");
        }
    }
}
