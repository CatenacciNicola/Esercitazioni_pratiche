using Esercitazione_17.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Esercitazione_17
{
    public class Program
    {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Configura la connessione al database
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddSingleton(new UserDao(connectionString));
            builder.Services.AddSingleton(new ClienteDao(connectionString));
            builder.Services.AddSingleton(new CameraDao(connectionString));
            builder.Services.AddSingleton(new TrattamentoDao(connectionString));
            builder.Services.AddSingleton(new PrenotazioneDao(connectionString));
            builder.Services.AddSingleton(new ServizioDao(connectionString));
            builder.Services.AddSingleton(new PrenotazioneServizioDao(connectionString));
            builder.Services.AddSingleton(new CercaDao(connectionString));

            // Aggiungi servizi di autenticazione
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = "/Account/Login";
                });

            // Aggiungi servizi MVC
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configura il middleware della pipeline delle richieste HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Usa l'autenticazione e l'autorizzazione
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
