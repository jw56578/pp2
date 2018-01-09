using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace pp2.Droid
{
    [Activity(Label = "pp2.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            RemoveStatusBar();
            IgnoreSSL();

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
            //part of removing status bar
            this.Window.AddFlags(WindowManagerFlags.Fullscreen | WindowManagerFlags.TurnScreenOn);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
        }
        void IgnoreSSL()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (s,c,chain,p) => true;

        }
        void RemoveStatusBar()
        {
            //https://forums.xamarin.com/discussion/83688/cannot-truely-hide-the-status-bar-on-android
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                // Kill status bar underlay added by FormsAppCompatActivity
                // Must be done before calling FormsAppCompatActivity.OnCreate()
                var statusBarHeightInfo = typeof(global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity).GetField("statusBarHeight", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                if (statusBarHeightInfo == null)
                {
                    statusBarHeightInfo = typeof(global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity).GetField("_statusBarHeight", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                }
                statusBarHeightInfo?.SetValue(this, 0);
            }

        }
       


    }
}
