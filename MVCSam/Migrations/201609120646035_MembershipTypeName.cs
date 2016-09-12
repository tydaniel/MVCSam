namespace MVCSam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipTypeName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "TypeName", c => c.String());
            Sql("UPDATE MembershipTypes SET TypeName = 'Pay as YOU GO'WHERE Id =1");
            Sql("UPDATE MembershipTypes SET TypeName = 'Monthly'WHERE Id =2");
            Sql("UPDATE MembershipTypes SET TypeName = 'Quarterly'WHERE Id =3");
            Sql("UPDATE MembershipTypes SET TypeName = 'Yearly'WHERE Id =4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "TypeName");
        }
    }
}
