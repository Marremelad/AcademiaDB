using AcademiaDB.Helpers;
using AcademiaDB.Repositories;
using AcademiaDB.UserInterface.MenuOptions;
using AcademiaDB.UserInterface.SelectionPrompts;

namespace AcademiaDB.UserInterface.Menus;

public class OrderStudentsByMenu
{
    private StudentRepository _studentRepository;

    public OrderStudentsByMenu(StudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public void DisplayOrderStudentsByMenu()
    {
        while (true)
        {
            Console.Clear();
            
            // A list of type string that is converted into a list of type MenuChoice.
            var choice = Prompt.DisplayMultiChoicePrompt("Select options to order by", MenuText.OrderStudentsByMenuText)
                .Where(MenuText.OrderStudentsByMenuText.ContainsKey)
                .Select(key => MenuText.OrderStudentsByMenuText[key])
                .ToList();
            
            if (PromptHelper.IsValidCombination(choice))
            {
                var (sortBy, orderBy) = PromptHelper.ApplyOptions(choice);
                Console.WriteLine(_studentRepository.GetOrderedStudentInformation(sortBy, orderBy));
                break;
            }
            Console.WriteLine("Invalid combination selected.");
            Thread.Sleep(2000);
        }
    }
}