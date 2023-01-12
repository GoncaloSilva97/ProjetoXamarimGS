using ProjetoXamarimGS.Prism.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoXamarimGS.Prism.Services
{
    public interface IWeatherAPI
    {
        Task<OneCallAPI> GetOneCallAPIAsync(string city);
    }
}
