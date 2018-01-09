using System;
using System.Net;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
/*
the examples show to use System.Json but this will not work with xamarin live player
just use newtonsoft which is better


*/
namespace pp2.Functions
{
    public static class HTTP
    {
      
        public static HttpWebRequest GetRequest(string url, string contentType, string method)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = contentType;
            request.Method = method;
            return request;
        }
        public static HttpWebRequest GetRequestWithBody(HttpWebRequest request,string body)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            request.ContentLength = byteArray.Length;
            using(Stream s = request.GetRequestStream())
            {
                s.Write(byteArray,0,byteArray.Length);
            }
            return request;
        }
        public static async Task<HttpWebResponse> GetResponse(HttpWebRequest request)
        {
            WebResponse response = await request.GetResponseAsync();
            return (HttpWebResponse)response;
        }
        public static async Task<string> GetResponseString(HttpWebResponse response)
        {
            using (Stream stream = response.GetResponseStream())
            {
                using(StreamReader reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
               
            }
        }
        public static JObject GetResponseJson(HttpWebResponse response)
        {
            using(Stream stream = response.GetResponseStream())
            {
                var serializer = new JsonSerializer();
                using (var sr = new StreamReader(stream))
                {
                    using (var jsonTextReader = new JsonTextReader(sr))
                    {
                        var json =  serializer.Deserialize(jsonTextReader) as JObject;
                        return json;
                    }
                }

            }
        }
        public static async Task<object> GetJson(string url)
        {
            var request = GetRequest(url, "application/json", "GET");
            using(var response = await GetResponse(request))
            {
                return GetResponseJson(response);
            }
        }
        public static async Task<JObject> PostJson(string url,Dictionary<string,string> body)
        {
            var request = GetRequest(url, "application/json", "POST");
            var json  = JsonConvert.SerializeObject(body);
            request = GetRequestWithBody(request,json);
            using (var response = await GetResponse(request))
            {
                return GetResponseJson(response);
            }
        }
    }
}
