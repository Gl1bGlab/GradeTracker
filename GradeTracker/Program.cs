using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GradeTracker.Constants;
using GradeTracker.Services;

class Program
{
    static async Task Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddSingleton<IGradeTrackerService, GradeTrackerService>();
        builder.Services.AddSingleton<IMenuService, MenuService>();

        using IHost host = builder.Build();

        using IServiceScope serviceScope = host.Services.CreateScope();
        IServiceProvider provider = serviceScope.ServiceProvider;
        IGradeTrackerService gradeTrackerService = provider.GetRequiredService<IGradeTrackerService>();
        gradeTrackerService.Run();

        await host.RunAsync();
    }
}