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
        builder.Services.AddSingleton<IMenuService, MenuService>();

        using IHost host = builder.Build();

        using IServiceScope serviceScope = host.Services.CreateScope();
        IServiceProvider provider = serviceScope.ServiceProvider;
        IMenuService menuService = provider.GetRequiredService<IMenuService>();
        menuService.PrintMenu(MenuTypeEnum.StartMenu);

        Console.WriteLine();

        await host.RunAsync();
    }
}