


using ProjetoXamarimGS.Prism.Models;
using System.Threading.Tasks;

namespace ProjetoXamarimGS.Prism.Services
{
    public interface IApiService
    {
       

        Task<Response<TokenResponse>> GetTokenAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            TokenRequest request);

        Task<bool> CheckConnection(string url);

        
    }


}