
using ProjetoXamarimGS.Helpers;

namespace ProjetoXamarimGS.Helperes
{
    public interface IMailHelper
    {
        Response SendEmail(string to, string subject, string body);
    }
}