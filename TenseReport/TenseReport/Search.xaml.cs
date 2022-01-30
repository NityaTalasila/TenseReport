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
    public partial class Search : ContentPage
    {
        public IList<Patient> Patients { get; private set; }
        public Search()
        {
            InitializeComponent();
            Patients = new List<Patient>();
            using (SQLiteConnection connex = new SQLiteConnection(App.pFilePath))
            {
                connex.CreateTable<Patient>();
                Patients = connex.Table<Patient>().ToList();

            }
            BindingContext = Patients;
        }
    }
}