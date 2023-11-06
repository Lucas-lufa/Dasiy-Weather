using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Dasiy_Weather
{
    // string baseAPI, string geoPart, string city, string limit, string APIKeyPart

    // http://api.openweathermap.org/geo/1.0/direct?q=Perth&limit=5&appid=3114e2f726350fe2d43b0c6913e03751

    internal class APIService
    {
        public class Locations
        {

        }
        public class Location
        {
            public string name { get; set; }
            public float lat { get; set; }
            public float lon { get; set; }
            public string country { get; set; }
            public string state { get; set; }

            public override string ToString()
            {
                return String.Format($"{name} {state} {country}");
            }


        }
       
        public APIService() { }

        static string baseAPI = "http://api.openweathermap.org/";

        static string geoPart = "geo/1.0/direct?q=";

        static string city = "";

        static string limit = "&limit=5";

        static string APIKeyPart = "&appid=3114e2f726350fe2d43b0c6913e03751";


        public async Task<List<Location>> GetLocation(string city)
        {
            string url = $"{baseAPI}{geoPart}{city}{limit}{APIKeyPart}";

            string responceString = await getResponce(url);
            await Console.Out.WriteLineAsync(responceString);

            return JsonConvert.DeserializeObject<List<Location>>(responceString);


        }

        private static async Task<string> getResponce(string url) 
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

            HttpResponseMessage response = await client.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }

    }
}
