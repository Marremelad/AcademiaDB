using AcademiaDB.Data;
using AcademiaDB.Helpers;
using AcademiaDB.Repositories;
using AcademiaDB.UserInterface.Menus;
using Microsoft.Extensions.DependencyInjection;

namespace AcademiaDB.Infrastructure;

public static class DiSetup
{
    // Adds dependencies to the DI container.
    public static IServiceProvider ConfigureServices()
    {
        return new ServiceCollection()
            .AddScoped<AcademiaContext>()
            .AddScoped<MainMenu>()
            .AddScoped<EmployeeMenu>()
            .AddScoped<EmployeeRepository>()
            .AddScoped<StudentMenu>()
            .AddScoped<StudentRepository>()
            .AddScoped<ViewRepository>()
            .AddScoped<Create>()
            .BuildServiceProvider();
    }
}