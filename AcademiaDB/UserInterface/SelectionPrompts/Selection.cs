using AcademiaDB.UserInterface.MenuOptions;
using Spectre.Console;

namespace AcademiaDB.UserInterface.SelectionPrompts;

public class Selection
{
    public static object DisplaySingleChoiceSelection<T>(string title, T choices)
    {
        if (choices is Dictionary<string, MenuText.Options> dictChoices)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(title)
                    .PageSize(10)
                    .MoreChoicesText("Move up and down to reveal more options")
                    .AddChoices(dictChoices.Keys));

            return dictChoices[choice];
        }

        if (choices is List<string> listChoices)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(title)
                    .PageSize(10)
                    .MoreChoicesText("Move up and down to reveal more options")
                    .AddChoices(listChoices));
            
            return choice;
        }

        throw new ArgumentException("Invalid choice type provided.");
    }


    // Display multi choice menu.
    public static List<string> DisplayMultiChoiceSelection(string title,
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