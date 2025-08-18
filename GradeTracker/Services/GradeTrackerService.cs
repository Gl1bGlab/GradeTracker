using GradeTracker.Constants;

namespace GradeTracker.Services
{
    public class GradeTrackerService : IGradeTrackerService
    {
        private readonly IMenuService _menuService;

        public GradeTrackerService(IMenuService menuService) 
        {
            _menuService = menuService;
        }

        public void Run() 
        {
            _menuService.HandleMenu();
            Console.ReadLine();
        }
    }
}