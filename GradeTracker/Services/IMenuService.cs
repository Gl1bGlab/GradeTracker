using System;
using GradeTracker.Constants;
using GradeTracker.Models;

namespace GradeTracker.Services
{
    public interface IMenuService 
    {
        MenuTypeEnum GetCurrentMenu();
        void HandleStartMenu();
        void HandleCourseMenu();
        void HandleListCourseMenu(List<Course> courses);
        void HandleAddCourseMenu(List<Course> courses);
    }
}