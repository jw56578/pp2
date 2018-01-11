using System;

using Xamarin.Forms;

using pp2.Views;

namespace pp2
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";

        public App()
        {
                             
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new NavigationPage(new LoginPage());
            else
                MainPage = new NavigationPage( new LoginPage());

            //cannot get a https request to work in IOS
            //ignoring certs works on IOS but not droid
            //this is insane, first android worked fine without this, then it suddenly didn't work
            //then it bombed with this here, then suddenly it worked with it here and now the http request will go through
            //no http request will work on any platform without overriding the certvalidation callback

            System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(
                delegate{
                  return true;
                }
            );
            

           
        }
    }
}
