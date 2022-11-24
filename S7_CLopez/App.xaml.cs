using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S7_CLopez
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
            //sincronización sqlite - servidor web rest

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
