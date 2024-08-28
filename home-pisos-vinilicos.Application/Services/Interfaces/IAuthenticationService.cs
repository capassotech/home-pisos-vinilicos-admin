using System.Threading.Tasks;

namespace home_pisos_vinilicos.Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> RegisterUserAsync(string email, string password);
    }
}
