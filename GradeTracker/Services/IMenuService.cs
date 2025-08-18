using GradeTracker.Constants;

namespace GradeTracker.Services
{
    public interface IMenuService 
    {
        string GetInput();
        void HandleMenu();
    }
}