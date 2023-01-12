using Prism;
using Prism.Ioc;
using ProjetoXamarimGS.Prism.Services;
using ProjetoXamarimGS.Prism.ViewModels;
using ProjetoXamarimGS.Prism.Views;
using Syncfusion.Licensing;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace ProjetoXamarimGS.Prism
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            SyncfusionLicenseProvider.RegisterLicense("NDcwOTE4QDMxMzkyZTMyMmUzMGJXQzNHR0g0UVBSUktxdFhLMklZbHM1SWpaMUJzTmNLRWRLb0wzR3dZMFk9");

            InitializeComponent();

            await NavigationService.NavigateAsync
                ($"/{nameof(ProjetoXamarimGSMasterDetailPage)}/NavigationPage/{nameof(LoginPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();

            containerRegistry.RegisterForNavigation<ProjetoXamarimGSMasterDetailPage, ProjetoXamarimGSMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<About, AboutViewModel>();
            containerRegistry.RegisterForNavigation<Credits, CreditsViewModel>();

            containerRegistry.RegisterForNavigation<Weather, WeatherViewModel>();
            containerRegistry.RegisterForNavigation<ProjetoXamarimGSMasterDetailPage, ProjetoXamarimGSMasterDetailPageViewModel>();
        }
    }
}
