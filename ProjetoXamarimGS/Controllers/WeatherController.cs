using Microsoft.AspNetCore.Mvc;
using ProjetoXamarimGS.Data;
using ProjetoXamarimGS.Data.Entities;
using ProjetoXamarimGS.Helpers;
using ProjetoXamarimGS.Models;

namespace ProjetoXamarimGS.Controllers
{
	public class WeatherController : Controller
	{
        //public IActionResult Weather()
        //{
        //	return View();
        //}
        private readonly IWForecastRepository _wForecastRepository;

        public WeatherController(IWForecastRepository wForecastRepository)
        {
            _wForecastRepository = wForecastRepository;
        }

        [HttpGet]
        public IActionResult SearchByCity()
        {
            var viewModel = new SearchCityViewModel();
            return View(viewModel);
        }  

        [HttpPost]
        public IActionResult SearchByCity(SearchCityViewModel model)
        {
            if (ModelState.IsValid)
            {
              return RedirectToAction("City", "Weather", new { city = model.CityName });
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult City(string city)
        {

            WeatherResponse weatherReponse = _wForecastRepository.GetForecast(city);
            CityViewModel viewModel = new CityViewModel();
            if (weatherReponse != null)
            {
                viewModel.Name = weatherReponse.Name;
                viewModel.Temperature = weatherReponse.Main.Temp;
                viewModel.Humidity = weatherReponse.Main.Humidity;
                viewModel.Pressure = weatherReponse.Main.Pressure;
                
                viewModel.Wind = weatherReponse.Wind.Speed;


                viewModel.Weather = weatherReponse.weather[0].Main;
            }
            return View(viewModel);
        }










    }
}
