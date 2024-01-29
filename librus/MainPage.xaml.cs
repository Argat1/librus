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
            //dodaj();
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

        /*public async void dodaj()
        {
            User x = new User()
            {
                Name = "Marcin",
                Username = "Gawron",
                Login = "000001n",
                Password = "admin123",
                IsTeacher = true
            };
            await App.Database.InsertUser(x);
            Subject sbj = new Subject()
            {
                Name = "Programowanie"
            };
            await App.Database.InsertSubject(sbj);
            Score s = new Score()
            {
                User_id = 1,
                Subject_id = 1,
                Subject_name = "Programowanie",
                Value = "5+",
                Date = DateTime.Now,
                Description = "Sprawdzian",
                Period = "Okres 1"
            };
            await App.Database.InsertScore(s);
        }*/
    }
}
