﻿using AcademiaDB.Models;
using AcademiaDB.Repositories;
using AcademiaDB.UserInterface.MenuOptions;
using AcademiaDB.UserInterface.SelectionPrompts;

namespace AcademiaDB.UserInterface.Menus;

public class DepartmentMenu
{
    private DepartmentRepository _departmentRepository;

    public DepartmentMenu(DepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public void DisplayDepartmentMenu()
    {
        var selection = Prompt.DisplaySingleChoicePrompt("Select an option",
            MenuText.DepartmentMenuText);

        var listOfDepartments = new List<Department>();
        switch (selection)
        {
            case MenuText.Options.AllDepartments:
                listOfDepartments = _departmentRepository.GetDepartments();
                break;
        }

        Console.WriteLine(_departmentRepository.GetDepartmentInformation(listOfDepartments));
    }
}