using System.Threading.Tasks;

namespace home_pisos_vinilicos_admin.Client.Services
{
    public interface IAuthenticationService
    {
        Task<string> LoginAsync(string email, string password);
    }
}
