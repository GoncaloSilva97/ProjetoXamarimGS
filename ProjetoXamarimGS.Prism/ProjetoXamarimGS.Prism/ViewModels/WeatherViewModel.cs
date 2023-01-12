using Example;
using Plugin.Connectivity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProjetoXamarimGS.Prism.Models;
using ProjetoXamarimGS.Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace ProjetoXamarimGS.Prism.ViewModels
{
	public class WeatherViewModel : ViewModelBase
	{
        private readonly INavigationService _navigationService;

        private IList<OneCallAPI> _weatherList;
        public IList<OneCallAPI> WeatherList
        {
            get
            {
                if (_weatherList == null)
                    _weatherList = new ObservableCollection<OneCallAPI>();
                return _weatherList;
            }
            set
            {
                _weatherList = value;
            }
        }

        private DelegateCommand _searchCommand;

        public string SearchCity { get; set; }




        public async Task APIAsync(string city)
        {
            var weather = await WeatherAPI.GetOneCallAPIAsync(city, "metric");
            
            WeatherList.Add(weather);
        }

        public WeatherViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            SearchCity = "london";
            Search();
            Title = "Weather";
            SearchCity = null;
        }

        public DelegateCommand SearchCommand => _searchCommand ?? (_searchCommand = new DelegateCommand(Search));

       
        private async void Search()
        {
            if (string.IsNullOrEmpty(SearchCity))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a City.", "Accept");
                return;
            }
            await APIAsync(SearchCity);
            SearchCity = string.Empty;
        }



    }
}
