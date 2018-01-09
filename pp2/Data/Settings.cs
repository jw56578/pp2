using System;
namespace pp2.Data
{
    public static partial class Settings
    {

        //public static string LoginUrl = "";
        //public static string DefaultUrl = "";
        //public static string RegisterUrl = "";

        public static bool IsAuthenticated 
        {

            get{
                return Get<bool>("IsAuthenticated");
            }
            set
            {
                Set("IsAuthenticated",value);
            }
        }
        public static bool IsRegistered
        {

            get
            {
                return Get<bool>("IsRegistered");
            }
            set
            {
                Set("IsRegistered", value);
            }
        }
        public static string TenancyName
        {

            get
            {
                return Get<string>("TenancyName");
            }
            set
            {
                Set("TenancyName", value);
            }
        }
        public static string Username
        {

            get
            {
                return Get<string>("Username");
            }
            set
            {
                Set("Username", value);
            }
        }
        public static string Password
        {

            get
            {
                return Get<string>("Password");
            }
            set
            {
                Set("Password", value);
            }
        }
        static T Get<T>(string key)
        {
            if (!App.Current.Properties.ContainsKey(key))
                return default(T);
            return (T)(App.Current.Properties[key]);
        }
        static void Set(string key,object value)
        {
            App.Current.Properties[key] = value;
        }
    }
}
