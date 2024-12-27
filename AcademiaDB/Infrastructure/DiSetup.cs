using AcademiaDB.Data;
using AcademiaDB.Repositories;
using AcademiaDB.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AcademiaDB.Infrastructure;

public static class DiSetup
{
    public static IServiceProvider ConfigureServices()
    {
        return new ServiceCollection()
            .AddScoped<AcademiaContext>()
            .AddScoped<EmployeeRepository>()
            .AddScoped<ViewRepository>()
            .AddScoped<MainMenu>()
            .BuildServiceProvider();
    }
}