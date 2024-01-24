using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace librus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : TabbedPage
    {
        User user;
        public TabbedPage1(User user)
        {
            InitializeComponent();
            this.user = user;
            
            UploadData();
        }

       

        public async void UploadData()
        {
            LV_UserScores.ItemsSource = await App.Database.GetScories();

            List<List<string>> period1_Scories = new List<List<string>>();
            List<List<string>> period2_Scories = new List<List<string>>();

            var subjects = await App.Database.GetSubjects();
            foreach (var subject in subjects)
            {
                List<string> row = new List<string>();

                var scoriesPeriodOne = await App.Database.GetScories(this.user.User_id, subject.Subject_id, "Okres 1");
                string scoriesPeriodOneText = "";
                foreach (var score in scoriesPeriodOne)
                {
                    scoriesPeriodOneText += score.Value + " ";
                }
                row.Add(scoriesPeriodOneText);
                row.Add(subject.Name);

                period1_Scories.Add(row);
            }

            foreach (var subject in subjects)
            {
                List<string> row = new List<string>();

                var scoriesPeriodTwo = await App.Database.GetScories(this.user.User_id, subject.Subject_id, "Okres 2");
                string scoriesPeriodTwoText = "";
                foreach (var score in scoriesPeriodTwo)
                {
                    scoriesPeriodTwoText += score.Value + " ";
                }
                row.Add(scoriesPeriodTwoText);
                row.Add(subject.Name);

                period2_Scories.Add(row);
            }

            LV_UserScores_Period_1.ItemsSource = period1_Scories;
            LV_UserScores_Period_2.ItemsSource = period2_Scories;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Score s = new Score()
            {
                User_id = user.User_id,
                Subject_id = 1,
                Subject_name = P_Subject_name.SelectedItem.ToString(),
                Value = P_Value.SelectedItem.ToString(),
                Date = DateTime.Now,
                Description = E_Description.Text,
                Period = "Okres 1"
            };
            await App.Database.InsertScore(s);
        }
    }
}