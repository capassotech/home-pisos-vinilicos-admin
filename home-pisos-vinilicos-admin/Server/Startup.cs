using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using home_pisos_vinilicos.Application.Services.Interfaces;
using home_pisos_vinilicos.Application.Services;
using System.IO;

namespace home_pisos_vinilicos_admin.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Inicializar Firebase directamente en Startup.cs
            InitializeFirebase();

            services.AddSingleton<IAuthenticationService, AuthenticationService>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        private void InitializeFirebase()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "firebase.json");
            if (File.Exists(path))
            {
                if (FirebaseApp.DefaultInstance == null)
                {
                    FirebaseApp.Create(new AppOptions()
                    {
                        Credential = GoogleCredential.FromFile(path)
                    });
                }
            }
            else
            {
                throw new FileNotFoundException("El archivo de configuración de Firebase no se encontró en la ruta especificada.", path);
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
