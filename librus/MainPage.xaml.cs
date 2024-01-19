using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace librus
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var users = await App.Database.GetUserFilter(login.Text, haslo.Text);
            if (login.Text.Length != 7 || users.Count == 0)
            {
                DisplayAlert("Blad", "Podano nieprawidlowe dane", "OK");
                return;
            }

            var user = users.ElementAt(0);
            Navigation.PushAsync(new TabbedPage1(user));
        }
    }
}
