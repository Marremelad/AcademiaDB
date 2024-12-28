﻿using AcademiaDB.Models;
using AcademiaDB.UserInterface.MenuOptions;
using Spectre.Console;

namespace AcademiaDB.UserInterface.SelectionPrompts;

public class Prompt
{
    
    // Displays a single choice prompt. Overloaded to handle multiple data structures.
    public static object DisplaySingleChoicePrompt<T>(string title, T choices)
    {
        var moreChoicesText = "Move up and down to reveal more options";
        
        // Handles a dictionary of type string and Menutext.Options.
        if (choices is Dictionary<string, MenuText.Options> dictString)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(title)
                    .PageSize(10)
                    .MoreChoicesText(moreChoicesText)
                    .AddChoices(dictString.Keys));

            return dictString[choice];
        }

        // Handles a list of type string.
        if (choices is List<string> listString)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(title)
                    .PageSize(10)
                    .MoreChoicesText(moreChoicesText)
                    .AddChoices(listString));
            
            return choice;
        }
        
        // Handles a list of type Employee.
        if (choices is List<Employee> listEmployee)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<Employee>()
                    .Title(title)
                    .PageSize(10)
                    .MoreChoicesText(moreChoicesText)
                    .AddChoices(listEmployee));
            
            return choice;
        }

        throw new ArgumentException("Invalid choice type provided.");
    }


    // Displays a multi choice prompt.
    public static List<string> DisplayMultiChoicePrompt(string title,
        Dictionary<string, MenuOptions.MenuText.Options> choices)
    {
        var multipleChoices = AnsiConsole.Prompt(
            new MultiSelectionPrompt<string>()
                .Title(title)
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .InstructionsText(
                    "[grey](Press [blue]<space>[/] to toggle an option, " + 
                    "[green]<enter>[/] to accept)[/]")
                .AddChoices(choices.Select(s => s.Key)));

        return multipleChoices;
    }
}