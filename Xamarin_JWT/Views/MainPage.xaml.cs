using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin_JWT.Helper;
using Xamarin_JWT.Services;
using Xamarin_JWT.Views;

namespace Xamarin_JWT
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {

        private JWTServices jWTServices = new JWTServices();

        public MainPage()
        {
            InitializeComponent();
        }


        async void GetCricketersClicked(object sender, System.EventArgs e)
        {
            if (UserSettings.ACCESS_TOKEN != null)
            {
                await Navigation.PushAsync(new CricketersPage());
            }
            else
            {
                WelcomeLabel.Text = "NO ACCESS TOKEN!!";
            }

        }

        async void LoginClicked(object sender, System.EventArgs e)
        {
            string userName = UserNameEntry.Text;
            string password = PasswordEntry.Text;

            var accessToken = await jWTServices.LoginAsync(userName, password);
            //System.Diagnostics.Debug.Write(accessToken);
            WelcomeLabel.Text = "YOUR TOKEN IS " + accessToken;
        }
    }
}
