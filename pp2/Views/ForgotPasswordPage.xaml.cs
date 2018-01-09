using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace pp2.Views
{
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
            string url = pp2.Data.Settings.ForgotPasswordUrl;
            Browser.Source = url;
        }
    }
}
