using System;
namespace pp2.Data
{
    public class Credentials
    {
        public bool IsRegistered
        {
            get;
            set;
        }
        public bool IsAuthenticated
        {
            get;
            set;
        }
        public string Username
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public string IpAddress
        {
            get;
            set;
        }
        public string GeoLocation
        {
            get;
            set;
        }
        public string MAC
        {
            get;
            set;

        }
        public string TenancyName
        {
            get;
            set;

        }
        public string Device
        {
            get;
            set;

        }
        public string Version
        {
            get;
            set;

        }
        public string Message
        {
            get;
            set;

        }
    }
}
/*
 * TenancyName –tenancy name entered on login screen

o UserName –user name entered on login screen
o Password – password entered on login screen
o Ip – the device’s WIFI IP address
o Geo – longitude and latitude in that order separated by a pipe ‘|’ character from
the devices GPS
o Mac – devices WIFI mac address or vendor mac address if WIFI mac address is
not available
o Dev – “Android Phone”, “Android Tablet”, ”Apple Phone”, “Apple Tablet”
o Ver – version of OS on device
*/