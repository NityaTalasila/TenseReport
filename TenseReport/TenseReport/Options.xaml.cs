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
    public partial class Options : ContentPage
    {
        public Options()
        {
            InitializeComponent();
        }
        async void NewPatient(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new FirstScreen(), false);
        }
        async void Continue(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new FirstScreen(), false);
        }
    }
}