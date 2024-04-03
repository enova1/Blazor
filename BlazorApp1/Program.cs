using BlazorApp1.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Headers;

namespace BlazorApp1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // Add configuration
            builder.Configuration.AddJsonFile("/appsettings.json");

            // Configure HttpClient
            builder.Services.AddScoped(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var baseAddress = configuration.GetValue<string>("ApiBaseUrl");
                var httpClient = new HttpClient { BaseAddress = new Uri(baseAddress!) };

                // Set the Accept header to accept JSON content
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return httpClient;
            });

            // Add services to the container.
            builder.Services.AddScoped<EmployeeService>(); // Register EmployeeService


            await builder.Build().RunAsync();
        }
    }
}
