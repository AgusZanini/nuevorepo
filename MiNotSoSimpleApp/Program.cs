using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp
{
    class Program
    {
        static async Task Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddHttpClient()
                .AddTransient<IApiService, ApiService>()
                .BuildServiceProvider();

            var apiService = serviceProvider.GetRequiredService<IApiService>();

            var myModels = await apiService.GetMyModelsAsync();
            foreach (var model in myModels)
            {
               Console.WriteLine($"Id: {model.Id}, Title: {model.Title}");
            }
        }
    }
}
