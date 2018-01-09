using System;
using Android.Gms.Common;

namespace pp2.Droid.Functions
{
    public static class GoogleApi
    {
        public static bool IsPlayServicesAvailable(Android.Content.Context context)
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(context);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    GoogleApiAvailability.Instance.GetErrorString(resultCode);
                else
                {
                    
                }
                return false;
            }
            else
            {
         
                return true;
            }
        }
    }
}
