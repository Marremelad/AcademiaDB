using AcademiaDB.UserInterface.Menus;
using Microsoft.Extensions.DependencyInjection;

namespace AcademiaDB.Infrastructure;

public static class Startup
{
    // Resolves the dependencies for the MainMenu class and runs the program.
    public static void Run()
    {
        var serviceProvider = DiSetup.ConfigureServices();
        var mainMenu = serviceProvider.GetRequiredService<MainMenu>();
        mainMenu.DisplayMainMenu();
    }
}