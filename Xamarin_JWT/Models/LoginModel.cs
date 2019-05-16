using System;
namespace Xamarin_JWT.Models
{
    public class LoginModel
    {
        public string UserName;
        public string Password;

        public LoginModel(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }
    }
}
