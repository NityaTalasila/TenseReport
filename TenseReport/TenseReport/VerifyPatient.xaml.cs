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
    public partial class VerifyPatient : ContentPage
    {
        public VerifyPatient()
        {
            InitializeComponent();
            txtName.Text = Application.Current.Properties["Name"].ToString();
            txtDate.Text = Application.Current.Properties["BirthDate"].ToString();
            txtContact.Text = Application.Current.Properties["Contact"].ToString();
            txtEmail.Text = Application.Current.Properties["Email"].ToString();
            MakeNewPatient();
        }
        async void Confirm(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new Options(), false);
        }
        async void Reset(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NewPatient(), false);
        }
        public void MakeNewPatient()
        {
            string name = Application.Current.Properties["Name"].ToString();
            string dob = Application.Current.Properties["BirthDate"].ToString();
            string contact = Application.Current.Properties["Contact"].ToString();
            string email = Application.Current.Properties["Email"].ToString();
            Patient newPat = new Patient(dob, name, contact, email);
            using (SQLiteConnection connex = new SQLiteConnection(App.pFilePath))
            {
                connex.CreateTable<Patient>();
                int rowsAdded = connex.Insert(newPat);
                App.currID = newPat.ID;
            }
        }
    }
}