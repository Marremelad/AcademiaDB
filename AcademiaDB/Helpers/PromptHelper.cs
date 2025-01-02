using System.Linq.Expressions;
using AcademiaDB.Models;
using AcademiaDB.UserInterface.MenuOptions;

namespace AcademiaDB.Helpers;

public static class PromptHelper
{
    // Check if the chosen combination of options is valid.
    public static bool IsValidCombination(List<MenuText.Options> selection)
    {
        
        // List containing lists of valid combinations.
        List<List<MenuText.Options>> validCombinations =
        [
            new() { MenuText.Options.SortByFirstName, MenuText.Options.OrderByDescending },
            new() { MenuText.Options.SortByLastName, MenuText.Options.OrderByDescending },
            new() { MenuText.Options.SortByFirstName, MenuText.Options.OrderByAscending },
            new() { MenuText.Options.SortByLastName, MenuText.Options.OrderByAscending }
        ];
        
        return validCombinations.Any(vc =>
            vc.SequenceEqual(selection)); 
    }
    
    // Applies the combination of options and calls the method to retrieve student information.
    public static Tuple<Expression<Func<Student, string>>, bool> ApplyOptions(List<MenuText.Options> selection)
    {
        Expression<Func<Student, string>> sortBy;
        bool orderBy;
        
        if ((int)selection[0] == 0 && (int)selection[1] == 2)
        {
            sortBy = s => s.StudentFirstName;
            orderBy = false; // Order by Descending.
        }
        else if ((int)selection[0] == 1 && (int)selection[1] == 2)
        {
            sortBy = s => s.StudentLastName;
            orderBy = false; // Order by Descending.
        }
        else if((int)selection[0] == 0 && (int)selection[1] == 3)
        {
            sortBy = s => s.StudentFirstName;
            orderBy = true; // Order by Ascending.
        }
        else
        {
            sortBy = s => s.StudentLastName;
            orderBy = true; // Order by Ascending.
        }

        return new Tuple<Expression<Func<Student, string>>, bool>(sortBy, orderBy);
    }
}