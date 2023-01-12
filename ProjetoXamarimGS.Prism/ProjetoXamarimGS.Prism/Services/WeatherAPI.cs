using Newtonsoft.Json;
using ProjetoXamarimGS.Prism.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoXamarimGS.Prism.Services
{
    public class WeatherAPI /*: IWeatherAPI*/
    {
        public const string KEY = "6c658a7aa229c0975216a9cc7c22ce74";
        public const string BASE_URL = "https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units={2}";




        public static async Task<OneCallAPI> GetOneCallAPIAsync(string city, string units)
        {
            OneCallAPI weather = new OneCallAPI();
            string url = String.Format(BASE_URL, city, KEY, units);
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<OneCallAPI>(content);
                weather = posts;
            }
            return weather;
        }
























        //public const string API_KEY = "&appid=6c658a7aa229c0975216a9cc7c22ce74";
        //public const string BASE_URL = "https://api.openweathermap.org/data/2.5/weather?q=";





        ////    string url = App.Current.Resources["WeatherAPI"].ToString() + $"weather?q={City}&appid=6c658a7aa229c0975216a9cc7c22ce74&units=metric&?format=json";
        ////    Response response = await _apiService.GetListAsync<ProductResponse>(url, "/api", "/Products");






        //public async Task<OneCallAPI> GetOneCallAPIAsync(string city)
        //{
        //    OneCallAPI weather = new OneCallAPI();
        //    string url = String.Format(BASE_URL, city, API_KEY, "&units=metric&?format=json");
        //    HttpClient httpClient = new HttpClient();
        //    var response = await httpClient.GetAsync(url);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        var posts = JsonConvert.DeserializeObject<OneCallAPI>(content);
        //        weather = posts;
        //    }
        //    return weather;
        //}
    }
}