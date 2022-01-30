using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TenseReport
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPatient : ContentPage
    {
        public NewPatient()
        {
            InitializeComponent();
        }
        async void Proceed(object sender, EventArgs e)
        {
            // Store all  Values  
            Application.Current.Properties["Name"] = txtName.Text;
            Application.Current.Properties["BirthDate"] = txtDate.Text;
            Application.Current.Properties["Contact"] = txtContact.Text;
            Application.Current.Properties["Email"] = txtEmail.Text;
            txtName.Text = string.Empty;
            txtDate.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtEmail.Text = string.Empty;

            await Navigation.PushModalAsync(new VerifyPatient(), false);

        }
    }
}