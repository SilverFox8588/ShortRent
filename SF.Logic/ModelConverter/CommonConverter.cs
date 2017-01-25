using SF.Domain;
using SF.Repositoriy.Entities;

namespace SF.Logic.ModelConverter
{
    public static class CommonConverter
    {
        public static Account ToDataModel(this AccountDM domain)
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
                CreatedOn = domain.CreatedOn,
                RowVersion = domain.RowVersion
            };
        }

        public static AccountDM ToDomainModel(this Account data)
        {
            return new AccountDM
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
                CreatedOn = data.CreatedOn,
                RowVersion = data.RowVersion
            };
        }
    }
}
