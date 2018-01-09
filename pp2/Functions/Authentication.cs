using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using pp2.Data;

namespace pp2.Functions
{
    public static class Authentication
    {
        public async static Task<Credentials> AttemptToAuthenticate(string username, string password, string tenacy)
        {
            JObject response = await Api.PostJson(Settings.LoginUrl, new Dictionary<string, string>(){
                {"TenancyName", tenacy},
                {"UsernameOrEmailAddress", username},
                {"Password",password},
                {"RememberMe","false"},
                {"ReturnUrl",""},
            });

            var error = response["error"];
            var success = response["success"];

            return new Credentials
            {
                //i have no idea what means that login was successful
                IsAuthenticated = !error.HasValues &&  bool.Parse(success.ToString()),
                Username= username,
                Password = password,
                TenancyName = tenacy
            };
        }
        public async static Task<Credentials>Register(Credentials registration)
        {
            var response = await HTTP.PostJson(Settings.LoginUrl, new Dictionary<string, string>(){
                {"TenancyName", registration.TenancyName},
                {"UserName", registration.Username},
                {"Password",registration.Password},
                {"Ip",registration.IpAddress},
                {"Geo",registration.GeoLocation},
                {"Mac",registration.MAC},
                {"Dev",registration.Device},
                {"Ver",registration.Version}

            });
            var error = response["error"];
            var message = error["message"].ToString();
            return registration;
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