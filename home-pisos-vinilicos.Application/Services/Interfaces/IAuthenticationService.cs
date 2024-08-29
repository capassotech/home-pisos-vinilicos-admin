using System.Collections.Generic;
using System.Threading.Tasks;
using static Google.Apis.Auth.OAuth2.Web.AuthorizationCodeWebApp;

namespace home_pisos_vinilicos.Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> RegisterUserAsync(string email, string password);
        Task<AuthResult> LoginUserAsync(string email, string password);
       // Task<List<User>> GetAllUsersAsync();

    }
}
