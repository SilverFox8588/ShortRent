namespace SF.Repositoriy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edituser_201701230323 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Password", c => c.String(maxLength: 32));
            AlterColumn("dbo.Accounts", "PasswordQuestion", c => c.String(maxLength: 50));
            AlterColumn("dbo.Accounts", "PasswordAnswer", c => c.String(maxLength: 50));
            AlterColumn("dbo.Accounts", "Email", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "Email", c => c.String());
            AlterColumn("dbo.Accounts", "PasswordAnswer", c => c.String());
            AlterColumn("dbo.Accounts", "PasswordQuestion", c => c.String());
            AlterColumn("dbo.Accounts", "Password", c => c.String());
        }
    }
}
