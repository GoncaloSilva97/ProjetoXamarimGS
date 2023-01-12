using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProjetoXamarimGS.Prism.ItemViewModels;
using ProjetoXamarimGS.Prism.Models;
using ProjetoXamarimGS.Prism.ViewModels;
using ProjetoXamarimGS.Prism.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Weather = ProjetoXamarimGS.Prism.Views.Weather;

namespace ProjetoXamarimGS.Prism.ViewModels
{
    public class ProjetoXamarimGSMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ProjetoXamarimGSMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        private void LoadMenus()
        {
            List<Menu> menus = new List<Menu>
            {
                new Menu
            {
                Icon = "ic_exit_to_app",
                PageName = $"{nameof(LoginPage)}",
                Title = "Login Page"
            },
            new Menu
            {
                 //Icon = "ic_shopping_cart",
                PageName = $"{nameof(Weather)}",
                Title = "Weather",
                IsLoginRequired = true
            },
            new Menu
            {
                 //Icon = "ic_history",
                PageName = $"{nameof(Credits)}",
                Title = "Credits",

            },
            new Menu
            {
                //Icon = "ic_person",
                PageName = $"{nameof(About)}",
                Title = "About"
            },

            };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title,
                    IsLoginRequired = m.IsLoginRequired
                }).ToList());
        }
    }
}




