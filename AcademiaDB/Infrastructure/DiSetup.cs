﻿using AcademiaDB.Data;
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
            .AddScoped<EmployeeRepository>()
            .AddScoped<ViewRepository>()
            .AddScoped<EmployeeMenu>()
            .AddScoped<MainMenu>()
            .AddScoped<Create>()
            .BuildServiceProvider();
    }
}