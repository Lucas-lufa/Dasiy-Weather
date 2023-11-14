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

    // https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=metric&appid={API key}

    // https://api.openweathermap.org/data/2.5/weather?lat=-31.9558964&lon=115.8605801&units=metric&appid=3114e2f726350fe2d43b0c6913e03751

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

        static string weather = "data/2.5/weather?";

        static string city = "";

        static string limit = "&limit=5";

        static string APIKeyPart = "3114e2f726350fe2d43b0c6913e03751";


        public static async Task<LocationWeather> GetLocationWeather (Location location)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?lat={location.lat}&lon={location.lon}&units=metric&appid={APIKeyPart}";             

            string responceString = await getResponce(url);
            await Console.Out.WriteLineAsync(responceString);

            return JsonConvert.DeserializeObject<LocationWeather>(responceString);
        }

        public static async Task<List<Location>> GetLocation(string city)
        {
            string url = $"{baseAPI}{geoPart}{city}{limit}&appid={APIKeyPart}";

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
