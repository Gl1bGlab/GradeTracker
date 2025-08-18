using System;
using GradeTracker.Constants;
using GradeTracker.Models;

namespace GradeTracker.Services
{
    public class MenuService : IMenuService
    {
        private readonly Stack<MenuTypeEnum> _menuHistory = new();

        public MenuTypeEnum GetCurrentMenu() 
        {
            if (_menuHistory.Count > 0)
            {
                return _menuHistory.Peek();
            }
            else 
            {
                return MenuTypeEnum.StartMenu;
            }
        }

        public void HandleStartMenu()
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
            }
            else 
            {
                Console.WriteLine("Invalid selection, please try again.");
                HandleStartMenu();
            }
        }

        public void HandleCourseMenu() 
        {
            var menuText = 
            """
            Course Management:
            (Enter the number of the Selection)
            1 - List Courses
            2 - Add a Course
            3 - Edit a Course
            4 - Remove a Course
            5 - Go Back
            """;

            Console.WriteLine(menuText);

            string[] validOptions = new string[5] { "1", "2", "3", "4", "5" };
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
                        _menuHistory.Push(MenuTypeEnum.EditCourseMenu);
                        break;
                    case "4":
                        _menuHistory.Push(MenuTypeEnum.RemoveCourseMenu);
                        break;
                    case "5":
                        _menuHistory.Pop();
                        break;
                    default:
                        break;
                }
            }
            else 
            {
                Console.WriteLine("Invalid selection, please try again.");
                HandleCourseMenu();
            }
        }

        public void HandleListCourseMenu(List<Course> courses)
        {
            foreach(var course in courses)
            {
                Console.WriteLine($"{course.Id} - {course.Title}");
            }

            _menuHistory.Pop();
        }

        public void HandleAddCourseMenu(List<Course> courses)
        {
            Course newCourse = new Course();
            newCourse.Id = courses.Count() + 1; 

            Console.WriteLine("Enter the name of the course:");
            newCourse.Title = Console.ReadLine();

            courses.Add(newCourse);
            _menuHistory.Pop();
        }

        private string GetInput() 
        {
            return Console.ReadLine();
        }
    }
}
