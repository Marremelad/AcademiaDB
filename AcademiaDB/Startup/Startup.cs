﻿using AcademiaDB.Infrastructure;
using AcademiaDB.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AcademiaDB.Startup;

public static class Run
{
    public static void Run()
    {
        var serviceProvider = DiSetup.ConfigureServices();
        var mainMenu = serviceProvider.GetRequiredService<MainMenu>();
        mainMenu.Display();
    }
}