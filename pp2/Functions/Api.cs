using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace pp2.Functions
{
    public static class Api
    {
        public async static Task<JObject> PostJson(string url,Dictionary<string,string> body)
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();//new ModernHttpClient.NativeMessageHandler());
            var json = JsonConvert.SerializeObject(body);
            var content = new System.Net.Http.StringContent(json,Encoding.UTF8,"application/json");
            var response = await client.PostAsync(url, content);
            string jsonText = "";
            jsonText = await response.Content.ReadAsStringAsync();
            var serializer = new JsonSerializer();
            var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(jsonText);
            return jsonObject;
        }
        public async static Task<string> PostJsonForString(string url, Dictionary<string, string> body)
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();//new ModernHttpClient.NativeMessageHandler());
            var json = JsonConvert.SerializeObject(body);
            var content = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            string jsonText = "";
            jsonText = await response.Content.ReadAsStringAsync();
            return jsonText;
        }
    }
}
