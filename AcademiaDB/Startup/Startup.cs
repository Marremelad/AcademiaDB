using AcademiaDB.Infrastructure;
using AcademiaDB.UserInterface.Menus;
using Microsoft.Extensions.DependencyInjection;

namespace AcademiaDB.Startup;

public static class Startup
{
    public static void Run()
    {
        var serviceProvider = DiSetup.ConfigureServices();
        var mainMenu = serviceProvider.GetRequiredService<MainMenu>();
        mainMenu.DisplayMainMenu();
    }
}