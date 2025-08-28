using ABCRetailers.Services;
//using System.Globalization;

namespace ABCRetailers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IAzureStorageService, AzureStorageService>();

            //Add logging.
            //builder.Services.AddLogging();

            var app = builder.Build();

            //var culture = new CultureInfo("en-US");
            //CultureInfo.DefaultThreadCurrentCulture = culture;
            //CultureInfo.DefaultThreadCurrentUICulture = culture;

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            //app.UseStaticFiles();
            app.UseRouting();
            app.MapStaticAssets();
            app.UseAuthorization();

            app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();


            app.Run();
        }
    }
}
