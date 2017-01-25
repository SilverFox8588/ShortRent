namespace SF.Repositoriy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edituser_2017012303 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        UserName = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                        Password = c.String(),
                        PasswordResetRequired = c.Boolean(nullable: false),
                        PasswordQuestion = c.String(),
                        PasswordAnswer = c.String(),
                        Email = c.String(),
                        Note = c.String(),
                        LastLoggedIn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                        RowVersion = c.Binary(),
                    })
                .PrimaryKey(t => t.AccountId);
            
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropTable("dbo.Accounts");
        }
    }
}
