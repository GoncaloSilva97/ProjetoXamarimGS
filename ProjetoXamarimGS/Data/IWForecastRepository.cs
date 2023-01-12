using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoXamarimGS.Data;
using ProjetoXamarimGS.Data.Entities;
using ProjetoXamarimGS.Helpers;
using ProjetoXamarimGS.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoXamarimGS.Data
{
    public interface IWForecastRepository 
    {
      

        WeatherResponse GetForecast(string city);

    }
}