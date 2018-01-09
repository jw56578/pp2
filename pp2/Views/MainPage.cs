using System;
using Xamarin.Forms;

namespace pp2
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page itemsPage = null;

    

        
            Children.Add(itemsPage);

        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
           
        }
    }
}
