using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ReportViewerWebsite.Data;
using Syncfusion.Blazor;
using System.Linq;

namespace ReportViewerWebsite
{
    public class Program
    {
        public Program() 
        {
            
        }

        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTExMUAzMTM4MmUzMjJlMzBJaWF3ZHF1ZHBMa1lvQmRCUHZlWThOSWhjNlNSVkxjVE92VGVmZ0F5akQ0PQ==");
            
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddSingleton<IReportService, ReportService>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSyncfusionBlazor();

            await builder.Build().RunAsync();
        }
    }
}
