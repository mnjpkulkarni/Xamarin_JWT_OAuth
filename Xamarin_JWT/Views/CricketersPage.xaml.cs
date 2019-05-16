using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin_JWT.Models;
using Xamarin_JWT.Services;

namespace Xamarin_JWT.Views
{
    public partial class CricketersPage : ContentPage
    {

        private JWTServices jWTServices = new JWTServices();
        ObservableCollection<CricketerModel> Cricketers;

        public CricketersPage()
        {
            InitializeComponent();
            LoadCricketers();
        }


        internal async void LoadCricketers()
        {
            var cricketersList = await jWTServices.GetCricketers();
            Cricketers = new ObservableCollection<CricketerModel>(cricketersList);
            CricketersList.ItemsSource = Cricketers;
        }

    }
}
