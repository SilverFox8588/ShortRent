namespace SF.Repositoriy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        Login = c.String(maxLength: 50),
                        UserName = c.String(maxLength: 50),
                        IsEnabled = c.Boolean(nullable: false),
                        Password = c.String(maxLength: 32),
                        PasswordResetRequired = c.Boolean(nullable: false),
                        PasswordQuestion = c.String(maxLength: 50),
                        PasswordAnswer = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Note = c.String(maxLength: 2000),
                        LastLoggedIn = c.DateTime(),
                        ClientId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        RowVersion = c.Binary(),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        IsEnabled = c.Boolean(nullable: false),
                        Note = c.String(maxLength: 2000),
                        UserQuota = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        RowVersion = c.Binary(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(),
                        Days = c.Short(),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.Byte(nullable: false),
                        Note = c.String(maxLength: 200),
                        OrderId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        RowVersion = c.Binary(),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        No = c.String(),
                        State = c.Byte(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        Days = c.Short(nullable: false),
                        GrandTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderSource = c.String(),
                        GuestInfo = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                        Note = c.String(maxLength: 2000),
                        RoomId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        RowVersion = c.Binary(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        State = c.Byte(nullable: false),
                        Type = c.Byte(nullable: false),
                        UnitPrice = c.Int(nullable: false),
                        ImageUrl = c.String(maxLength: 200),
                        IsEnabled = c.Boolean(nullable: false),
                        Note = c.String(maxLength: 2000),
                        ClientId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        RowVersion = c.Binary(),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Accounts", "ClientId", "dbo.Clients");
            DropIndex("dbo.Rooms", new[] { "ClientId" });
            DropIndex("dbo.Orders", new[] { "RoomId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.Accounts", new[] { "ClientId" });
            DropTable("dbo.Rooms");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Clients");
            DropTable("dbo.Accounts");
        }
    }
}
