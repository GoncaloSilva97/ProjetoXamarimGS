using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Crmf;
using ProjetoXamarimGS.Data;
using ProjetoXamarimGS.Data.Entities;
using ProjetoXamarimGS.Helpers;
using ProjetoXamarimGS.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serializers;
using System.Text.Json;

namespace ProjetoXamarimGS.Data
{

    public class WForecastRepository : IWForecastRepository
    {

        
        public WeatherResponse GetForecast(string city)
        {

            string APP_ID = Helperes.ApiAuthenticationHelperes.Authentication;
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/");
            var request = new RestRequest($"weather?q={city}&appid={APP_ID}&units=metric&?format=json", Method.Get);
            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                return content?.ToObject<WeatherResponse>();

            }
            else
                return null;





        }








    }
}