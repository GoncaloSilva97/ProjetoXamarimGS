using DryIoc;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProjetoXamarimGS.Prism;
using ProjetoXamarimGS.Prism.Models;
using ProjetoXamarimGS.Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoXamarimGS.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
       
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private string _password;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _loginCommand;

        public LoginPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Login";
            IsEnabled = true;
        }

        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(Login));



        public string Email { get; set; }


        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }


        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "EmailError", "Accept");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "PasswordError", "Accept");
                return;
            }


            IsRunning = true;
            IsEnabled = false;

            var request = new TokenRequest
            {
                Password = Password,
                Username = Email
            };

            var url = App.Current.Resources["UrlAPI"].ToString();
            //var response = await _apiService.GetTokenAsync(url, "Api", "/Users", request);

            var response = await _apiService.GetTokenAsync(url, "Account", "/CreateToken", request);


            IsRunning = false;
            IsEnabled = true;


            if (!response.IsSuccess)
            {
                
                await App.Current.MainPage.DisplayAlert("Error", "Email or password incorrect.", "Accept");
                Password = string.Empty;
                return;
            }

            await NavigationService.NavigateAsync
                ($"/{nameof(Weather)}/NavigationPage/{nameof(Weather)}");
            await _navigationService.NavigateAsync("Weather");


            //await App.Current.MainPage.DisplayAlert("Ok", "Boa, entrámos!!", "Accept");


        }







    }
}