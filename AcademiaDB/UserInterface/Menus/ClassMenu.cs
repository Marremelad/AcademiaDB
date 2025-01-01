using AcademiaDB.Data;
using AcademiaDB.Helpers;
using AcademiaDB.Repositories;
using AcademiaDB.UserInterface.MenuOptions;
using AcademiaDB.UserInterface.SelectionPrompts;

namespace AcademiaDB.UserInterface.Menus;

public class ClassMenu
{
    private ClassRepository _classRepository;

    public ClassMenu(ClassRepository classRepository)
    {
        _classRepository = classRepository;
    }

    public void DisplayClassMenu()
    {
        Console.WriteLine(_classRepository.GetClassInformation());
    }
}