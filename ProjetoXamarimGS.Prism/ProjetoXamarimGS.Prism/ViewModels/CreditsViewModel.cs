using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoXamarimGS.Prism.ViewModels
{
    public class CreditsViewModel : ViewModelBase
    {
        public CreditsViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Credits";
        }
    }
}
