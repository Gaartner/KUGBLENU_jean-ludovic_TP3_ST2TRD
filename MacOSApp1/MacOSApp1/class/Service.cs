using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MacOSApp1
{
    public class Service
    {

        // fetch the api at each request

        public static async Task<Weather.Root> RequeteWeather(string constrequete)
        {
            // api in clear text ready to change 
            var api = "bbe8fe51aa7d630332569e6f1e92fb77";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                // format for 
                Method = HttpMethod.Get,
                RequestUri =
                    new Uri(String.Format("https://api.openweathermap.org/data/2.5/weather?{0}&units=metric&appid={1}",
                        constrequete, api))
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var e = await response.Content.ReadAsStringAsync();
                var objDeserial = JsonConvert.DeserializeObject<Weather.Root>(e);
                // if objDeserial is void throw exception
                return objDeserial ?? throw new InvalidOperationException();
            }
        }

        public static async Task<Forecast.Root> RequeteForecast(string constrequete)
        {
            // api in clear text ready to change 
            var api = "bbe8fe51aa7d630332569e6f1e92fb77";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                // format for 
                Method = HttpMethod.Get,
                RequestUri =
                    new Uri(String.Format("https://api.openweathermap.org/data/2.5/forecast?{0}&units=metric&appid={1}",
                        constrequete, api))
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var e = await response.Content.ReadAsStringAsync();
                var objDeserial = JsonConvert.DeserializeObject<Forecast.Root>(e);
                // if objDeserial is void throw exception
                return objDeserial ?? throw new InvalidOperationException();
            }
        }

        public static async Task<Airpolution.Root> RequeteAirPolution(double lat,double lon)
        {
            // api in clear text ready to change 
            var api = "bbe8fe51aa7d630332569e6f1e92fb77";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                // format for 
                Method = HttpMethod.Get,
                RequestUri =
                    new Uri(String.Format(
                        "https://api.openweathermap.org/data/2.5/air_pollution?lat={0}&lon={1}&appid={2}", lat,lon,
                        api))
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var e = await response.Content.ReadAsStringAsync();
                var objDeserial = JsonConvert.DeserializeObject<Airpolution.Root>(e);
                // if objDeserial is void throw exception
                return objDeserial ?? throw new InvalidOperationException();
            }
        }
    }
}