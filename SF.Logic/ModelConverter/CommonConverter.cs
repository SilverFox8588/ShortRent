using SF.Domain;
using SF.Repositoriy.Entities;

namespace SF.Logic.ModelConverter
{
    public static class CommonConverter
    {
        public static Account ToDataModel(this AccountDomainModel domain)
        {
            return new Account
            {
                AccountId = domain.AccountId,
                Login = domain.Login,
                UserName = domain.UserName,
                IsEnabled = domain.IsEnabled,
                Password = domain.Password,
                PasswordResetRequired = domain.PasswordResetRequired,
                PasswordQuestion = domain.PasswordQuestion,
                PasswordAnswer = domain.PasswordAnswer,
                Email = domain.Email,
                Note = domain.Note,
                LastLoggedIn = domain.LastLoggedIn,
                CreatedOn = domain.CreatedOn
            };
        }

        public static AccountDomainModel ToDomainModel(this Account data)
        {
            return new AccountDomainModel
            {
                AccountId = data.AccountId,
                Login = data.Login,
                UserName = data.UserName,
                IsEnabled = data.IsEnabled,
                Password = data.Password,
                PasswordResetRequired = data.PasswordResetRequired,
                PasswordQuestion = data.PasswordQuestion,
                PasswordAnswer = data.PasswordAnswer,
                Email = data.Email,
                Note = data.Note,
                LastLoggedIn = data.LastLoggedIn,
                CreatedOn = data.CreatedOn
            };
        }

        public static Client ToDataModel(this ClientDomainModel domain)
        {
            return new Client
            {
                ClientId = domain.ClientId,
                Name = domain.Name,
                IsEnabled = domain.IsEnabled,
                Note = domain.Note,
                UserQuota = domain.UserQuota,
                CreatedOn = domain.CreatedOn
            };
        }

        public static ClientDomainModel ToDomainModel(this Client data)
        {
            return new ClientDomainModel
            {
                ClientId = data.ClientId,
                Name = data.Name,
                IsEnabled = data.IsEnabled,
                Note = data.Note,
                UserQuota = data.UserQuota,
                CreatedOn = data.CreatedOn
            };
        }

        public static Order ToDataModel(this OrderDomainModel domain)
        {
            return new Order
            {
                OrderId = domain.OrderId,
                Name = domain.Name,
                No = domain.No,
                State = domain.State,
                StartDate = domain.StartDate,
                Days = domain.Days,
                GrandTotal = domain.GrandTotal,
                OrderSource = domain.OrderSource,
                GuestInfo = domain.GuestInfo,
                IsEnabled = domain.IsEnabled,
                Note = domain.Note,
                RoomId = domain.RoomId,
                CreatedOn = domain.CreatedOn
            };
        }

        public static OrderDomainModel ToDomainModel(this Order data)
        {
            return new OrderDomainModel
            {
                OrderId = data.OrderId,
                Name = data.Name,
                No = data.No,
                State = data.State,
                StartDate = data.StartDate,
                Days = data.Days,
                GrandTotal = data.GrandTotal,
                OrderSource = data.OrderSource,
                GuestInfo = data.GuestInfo,
                IsEnabled = data.IsEnabled,
                Note = data.Note,
                RoomId = data.RoomId,
                CreatedOn = data.CreatedOn
            };
        }

        public static OrderItem ToDataModel(this OrderItemDomainModel domain)
        {
            return new OrderItem
            {
                OrderItemId = domain.OrderItemId,
                StartDate = domain.StartDate,
                Days = domain.Days,
                UnitPrice = domain.UnitPrice,
                Total = domain.Total,
                Type = domain.Type,
                Note = domain.Note,
                OrderId = domain.OrderId,
                CreatedOn = domain.CreatedOn
            };
        }

        public static OrderItemDomainModel ToDomainModel(this OrderItem data)
        {
            return new OrderItemDomainModel
            {
                OrderItemId = data.OrderItemId,
                StartDate = data.StartDate,
                Days = data.Days,
                UnitPrice = data.UnitPrice,
                Total = data.Total,
                Type = data.Type,
                Note = data.Note,
                OrderId = data.OrderId,
                CreatedOn = data.CreatedOn
            };
        }

        public static Room ToDataModel(this RoomDomainModel domain)
        {
            return new Room
            {
                RoomId = domain.RoomId,
                Name = domain.Name,
                State = domain.State,
                Type = domain.Type,
                UnitPrice = domain.UnitPrice,
                ImageUrl = domain.ImageUrl,
                IsEnabled = domain.IsEnabled,
                Note = domain.Note,
                ClientId = domain.ClientId,
                CreatedOn = domain.CreatedOn
            };
        }

        public static RoomDomainModel ToDomainModel(this Room data)
        {
            return new RoomDomainModel
            {
                RoomId = data.RoomId,
                Name = data.Name,
                State = data.State,
                Type = data.Type,
                UnitPrice = data.UnitPrice,
                ImageUrl = data.ImageUrl,
                IsEnabled = data.IsEnabled,
                Note = data.Note,
                ClientId = data.ClientId,
                CreatedOn = data.CreatedOn
            };
        }
    }
}
