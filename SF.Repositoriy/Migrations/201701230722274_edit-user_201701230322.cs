namespace SF.Repositoriy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edituser_201701230322 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Login", c => c.String(maxLength: 50));
            AlterColumn("dbo.Accounts", "UserName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "UserName", c => c.String());
            AlterColumn("dbo.Accounts", "Login", c => c.String());
        }
    }
}
