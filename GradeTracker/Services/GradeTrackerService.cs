using System.Collections.Generic;
using GradeTracker.Constants;
using GradeTracker.Models;

namespace GradeTracker.Services
{
    public class GradeTrackerService : IGradeTrackerService
    {
        private readonly IMenuService _menuService;
        public List<Course> Courses = new List<Course>();

        public GradeTrackerService(IMenuService menuService) 
        {
            _menuService = menuService;
        }

        public void Run() 
        {
            var currentMenu = _menuService.GetCurrentMenu();

            switch (currentMenu)
            {
                case MenuTypeEnum.StartMenu:
                    _menuService.HandleStartMenu();
                    break;
                case MenuTypeEnum.CourseMenu:
                    _menuService.HandleCourseMenu();
                    break;
                case MenuTypeEnum.ListCourseMenu:
                    _menuService.HandleListCourseMenu(Courses);
                    break;
                case MenuTypeEnum.AddCourseMenu:
                    _menuService.HandleAddCourseMenu(Courses);
                    break;
                default:
                    Console.WriteLine("nope");
                    break;
            }
                
            Run();
        }
    }
}