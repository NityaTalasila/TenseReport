using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TenseReport
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void NewPatient(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NewPatient(), false);
        }
        async void UpdatePatient(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new Search(), false);
        }
    }
}
