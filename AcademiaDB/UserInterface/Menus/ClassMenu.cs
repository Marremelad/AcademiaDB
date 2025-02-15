﻿using AcademiaDB.Repositories;

namespace AcademiaDB.UserInterface.Menus;

public class ClassMenu
{
    private ClassRepository _classRepository;

    public ClassMenu(ClassRepository classRepository)
    {
        _classRepository = classRepository;
    }

    // Displays the class menu.
    public void DisplayClassMenu()
    {
        var listOfClasses = _classRepository.GetClasses();
        Console.WriteLine(_classRepository.GetClassInformation(listOfClasses));
    }
}