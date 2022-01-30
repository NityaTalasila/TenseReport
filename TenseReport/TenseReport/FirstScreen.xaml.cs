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
    public partial class FirstScreen : ContentPage
    {
        public FirstScreen()
        {
            InitializeComponent();
        }
        async void Continue(object sender, EventArgs e)
        {
            // Store all  Values  
            Application.Current.Properties["SBP1"] = SBP1.Text;
            Application.Current.Properties["DBP1"] = DBP1.Text;
            Application.Current.Properties["SBP2"] = SBP2.Text;
            Application.Current.Properties["DBP2"] = DBP2.Text;
            Application.Current.Properties["Clinic"] = Clinic.Text;
            SBP1.Text = string.Empty;
            DBP1.Text = string.Empty;
            SBP2.Text = string.Empty;
            DBP2.Text = string.Empty;

            await Navigation.PushModalAsync(new VerifyData(), false);

        }
    }
}