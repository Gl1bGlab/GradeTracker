using System;
using GradeTracker.Constants;


namespace GradeTracker.Services
{
    public class MenuService : IMenuService
    {
        private readonly Stack<MenuTypeEnum> _menuHistory = new();

        public string GetInput() 
        {
            return Console.ReadLine();
        }

        public void HandleMenu()
        {
            if (_menuHistory.Count == 0)
            {
                HandleStartMenu();
            }
            else
            {
                switch (_menuHistory.Peek())
                {
                    case MenuTypeEnum.StartMenu:
                        HandleStartMenu();
                        break;
                    case MenuTypeEnum.CourseMenu:
                        HandleCourseMenu();
                        break;
                    default:
                        Console.WriteLine("nope");
                        break;
                }
            }
        }

        private void HandleStartMenu()
        {
            var menuText = 
            """
            Welcome to GradeTracker, what would you like to do?
            (Enter the number of the selection)
            1 - Course Management
            2 - Student Management
            3 - Exit GradeTracker
            """;

            Console.WriteLine(menuText);

            string[] validOptions = new string[3] { "1", "2", "3" };
            var input = GetInput();
            
            if (validOptions.Contains(input))
            {
                switch (input)
                {
                    case "1":
                        _menuHistory.Push(MenuTypeEnum.CourseMenu);
                        break;
                    case "2":
                        _menuHistory.Push(MenuTypeEnum.StudentMenu);
                        break;
                    case "3":
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;

                }

                HandleMenu();
            }
            else 
            {
                Console.WriteLine("Invalid selection, please try again.");
                HandleStartMenu();
            }
        }

        private void HandleCourseMenu() 
        {
            var menuText = 
            """
            Course Management:
            (Enter the number of the Selection)
            1 - List Courses
            2 - Add a Course
            3 - Remove a Course
            4 - Go Back
            """;

            Console.WriteLine(menuText);

            string[] validOptions = new string[4] { "1", "2", "3", "4" };
            var input = GetInput();
            
            if (validOptions.Contains(input))
            {
                switch (input)
                {
                    case "1":
                        _menuHistory.Push(MenuTypeEnum.ListCourseMenu);
                        break;
                    case "2":
                        _menuHistory.Push(MenuTypeEnum.AddCourseMenu);
                        break;
                    case "3":
                        _menuHistory.Push(MenuTypeEnum.RemoveCourseMenu);
                        break;
                    case "4":
                        _menuHistory.Pop();
                        break;
                    default:
                        break;
                }
                
                HandleMenu();
            }
            else 
            {
                Console.WriteLine("Invalid selection, please try again.");
                HandleCourseMenu();
            }
        }
    }
}
