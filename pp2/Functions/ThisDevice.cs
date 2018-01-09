using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using Plugin.DeviceInfo;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;

namespace pp2.Functions
{
    public static class ThisDevice
    {
        //https://stackoverflow.com/questions/6803073/get-local-ip-address/6803109#6803109
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        //https://forums.xamarin.com/discussion/2233/device-mac-address
        public static string GetMAC()
        {
            foreach (var netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (netInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                    netInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    var address = netInterface.GetPhysicalAddress();
                    return BitConverter.ToString(address.GetAddressBytes());

                }
            }

            return "NoMac";

        }
        public static string GetOSVersion()
        {
            //https://github.com/jamesmontemagno/DeviceInfoPlugin
            return CrossDeviceInfo.Current.Version;
        }
        public static string GetDescription()
        {
            //Dev – “Android Phone”, “Android Tablet”, ”Apple Phone”, “Apple Tablet”
            if (Device.RuntimePlatform == Device.iOS)
            {
                return "Apple " + (CrossDeviceInfo.Current.Idiom == Plugin.DeviceInfo.Abstractions.Idiom.Phone ? "Phone" : "Tablet");
            }

            if (Device.RuntimePlatform == Device.Android)
            {
                return "Android " + (CrossDeviceInfo.Current.Idiom == Plugin.DeviceInfo.Abstractions.Idiom.Phone ? "Phone" : "Tablet");
            }
            return null;
        }
        //not sure what is going on with this
        //https://jamesmontemagno.github.io/GeolocatorPlugin/GettingStarted.html
        //I added those entries to info.plist many different ways but it wasn't working
        //it kept throwing an exception about not having permission
        //then suddenly it worked, i have no idea why

        public static async Task<string> GetLongLatString()
        {
            Position position = null;
            string longlat = "";
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100;

                position = await locator.GetLastKnownLocationAsync();

                if (position != null)
                {
                    //got a cahched position, so let's use it.
                    return position.Longitude + "|" + position.Latitude;
                }

                if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                {
                    //not available or enabled
                    return "";
                }

                position = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);

            }
            catch (Exception ex)
            {
                //Display error as we have timed out or can't get location.
            }

            if (position == null)
                return "";

            longlat = position.Longitude + "|" + position.Latitude;


            return (longlat);
        }
    }
}
