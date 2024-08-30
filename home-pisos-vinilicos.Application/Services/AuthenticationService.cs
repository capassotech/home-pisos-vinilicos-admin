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


        public async Task<AuthResult> LoginUserAsync(string email, string password)
        {
            try
            {
                // Obtenemos el usuario por correo electrónico
                var user = await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(email);

                if (user != null)
                {
                    var token = await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(user.Uid);

                    return new AuthResult
                    {
                        IsSuccess = true,
                        Message = "User logged in successfully.",
                        Token = token
                    };
                }

                return new AuthResult
                {
                    IsSuccess = false,
                    Message = "User not found."
                };
            }
            catch (Exception ex)
            {
                return new AuthResult
                {
                    IsSuccess = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }
    }

    public class AuthResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}

    

