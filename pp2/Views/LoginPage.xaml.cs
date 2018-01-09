using System;
using System.Collections.Generic;

using Xamarin.Forms;
using pp2.ViewModels;
using pp2.Functions;
using pp2.Data;

namespace pp2.Views
{
    public partial class LoginPage : ContentPage
    {
        LoginViewModel viewModel;

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new LoginViewModel(){
                UsernameOrEmailAddress = "demoaccount",
                Password = "demoaccount",
                TenancyName= "vuteur"
            };
           
          AddEntries();
        }
        ///  //i need to use the custom renderer NoHelperEntry but I cannot get it to work through xaml
        /// it keeps saying it can't find the thing in the dll
        /// i notice that the pinpoint assembly (dll) is not moved into the bin folder of the ios and droid project, terrible
        /// maybe the answer is here, not sure
        /// https://forums.xamarin.com/discussion/27307/assembly-for-xmlns-locate-not-found-forms-project-with-xaml
        /// </summary>
        void AddEntries()
        {

            var campusKey = new NoHelperEntry()
            {
                Placeholder = "Campus Key"
            };
            campusKey.BindingContext = viewModel;
            campusKey.SetBinding(Entry.TextProperty, "TenancyName", BindingMode.TwoWay);
            Inputs.Children.Insert(2,campusKey);

            var username = new NoHelperEntry()
            {
                Placeholder = "Username"
            };
            username.BindingContext = viewModel;
            username.SetBinding(Entry.TextProperty, "UsernameOrEmailAddress", BindingMode.TwoWay);
            Inputs.Children.Insert(4,username);

            var password = new NoHelperEntry()
            {
                Placeholder = "Password"
            };
            password.BindingContext = viewModel;
            password.SetBinding(Entry.TextProperty, "Password", BindingMode.TwoWay);
            Inputs.Children.Insert(6,password);

        }

        async void Handle_ForgotPasswordClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPasswordPage());
        }

        async void Handle_LoginClicked(object sender, System.EventArgs e)
        {
            viewModel.IsBusy = true;
            viewModel.Message = "Attempting to log in";
    
            var creds = await Authentication.AttemptToAuthenticate(viewModel.UsernameOrEmailAddress,viewModel.Password,viewModel.TenancyName);
            if(creds.IsAuthenticated)
            {
                string longlat = await ThisDevice.GetLongLatString();

                viewModel.Message = "Log in successful, registering device";
                creds = await Authentication.Register(new Credentials(){
                    Username = creds.Username,
                    Password = creds.Password,
                    TenancyName = creds.TenancyName,
                    IpAddress = ThisDevice.GetLocalIPAddress(),
                    MAC = ThisDevice.GetMAC(),
                    Version = ThisDevice.GetOSVersion(),
                    Device = ThisDevice.GetDescription(),
                    GeoLocation = longlat


                });
                viewModel.Message = "Device registered";
                //save info permanently
                Settings.IsRegistered = true;
                Settings.TenancyName = creds.TenancyName;
                Settings.Username = creds.Username;
                Settings.Password = creds.Password;
                viewModel.IsBusy = false;
                viewModel.Message = "Going to dashbaord";          
                await Navigation.PushAsync(new Dashboard());
                //i don't want the user to be able to go back to this page
                Navigation.RemovePage(this);

            }else{
                viewModel.Message = "Log in failed";
            }
            viewModel.IsBusy = false;


        }
    }
}
