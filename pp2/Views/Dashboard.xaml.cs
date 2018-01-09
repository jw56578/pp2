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
            string url = string.Format(Settings.DefaultUrl, "demoaccount", "demoaccount", "vuteur");
            Browser.Source = url;
        }
    }
}
