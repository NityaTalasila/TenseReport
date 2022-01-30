using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TenseReport.data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TenseReport
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerifyData : ContentPage
    {
        public VerifyData()
        {
            InitializeComponent();
            SBP1.Text = Application.Current.Properties["SBP1"].ToString();
            DBP1.Text = Application.Current.Properties["DBP1"].ToString();
            SBP2.Text = Application.Current.Properties["SBP2"].ToString();
            DBP2.Text = Application.Current.Properties["DBP2"].ToString();
            SaveRecord();
        }

        async void Reset(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new FirstScreen(), false);
        }
        private void Confirm(object sender, EventArgs args)
        {
            DisplayAlert("Success!", "New patient screening saved", "OK");
        }
        private void SaveRecord()
        {
            int.TryParse(Application.Current.Properties["SBP1"].ToString(),out int sbp1);
            int.TryParse(Application.Current.Properties["DBP1"].ToString(), out int dbp1);
            int.TryParse(Application.Current.Properties["SBP2"].ToString(), out int sbp2);
            int.TryParse(Application.Current.Properties["DBP2"].ToString(), out int dbp2);

            Screening testScreen = new Screening(sbp1, dbp1, DateTime.Now);
            testScreen.AddRecording(sbp2, dbp2, DateTime.Now);
            List<string> emailList = new List<string>();
            emailList.Add(Application.Current.Properties["Clinic"].ToString());
            testScreen.SendEmail(emailList);
            //using (SQLiteConnection connex = new SQLiteConnection(App.pFilePath))
            //{
            //    connex.CreateTable<Patient>();
            //    List<Patient> toUpdateList = connex.Table<Patient>().ToList();
            //    Patient toUpdate = null;
            //    foreach (Patient pat in toUpdateList)
            //    {
            //        if (pat.ID == App.currID)
            //        {
            //            toUpdate = pat;
            //        }
            //    }
            //    toUpdate.BeginScreening(sbp1, dbp1, DateTime.Now);
            //    toUpdate.AddToScreening(sbp2, dbp2, DateTime.Now);
            //    connex.Update(toUpdate);
            //}
        }
    }
}