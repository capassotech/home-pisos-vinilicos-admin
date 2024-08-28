using System;
using System.Threading.Tasks;
using FirebaseAdmin.Auth;
using home_pisos_vinilicos.Application.Services.Interfaces;

namespace home_pisos_vinilicos.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<string> RegisterUserAsync(string email, string password)
        {
            try
            {
                var userRecordArgs = new UserRecordArgs()
                {
                    Email = email,
                    Password = password,
                    EmailVerified = false,
                    Disabled = false,
                };

                var userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(userRecordArgs);
                return $"User created successfully: {userRecord.Uid}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
