using System;
using System.Collections.Generic;

using Xamarin.Forms;
using pp2.Data;

namespace pp2.Views
{
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            //webview will not work unless the url is https
            string url = string.Format(Settings.DefaultUrl, Settings.Username, Settings.Password, Settings.TenancyName);
            Browser.Source = url;
        }
    }
}
