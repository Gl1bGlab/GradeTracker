using GradeTracker.Constants;

namespace GradeTracker.Services
{
    public interface IMenuService 
    {
        string GetInput();
        void PrintMenu(MenuTypeEnum menuType);
    }
}