using ContravvenzioniWebApp.Data;

namespace ContravvenzioniWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<AnagraficaDAO>();
            builder.Services.AddScoped<ViolazioneDAO>();
            builder.Services.AddScoped<VerbaleDAO>();
            builder.Services.AddScoped<ViolazioniAVerbaleDAO>();
            var app = builder.Build();
            var configuration = builder.Configuration;

            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
