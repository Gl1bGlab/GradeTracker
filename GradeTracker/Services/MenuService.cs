using System;
using GradeTracker.Constants;


namespace GradeTracker.Services
{
    public class MenuService : IMenuService
    {
        public string GetInput() {
            return Console.ReadLine();
        }
        
        public void PrintMenu(MenuTypeEnum menuType)
        {
            switch (menuType)
            {
                case MenuTypeEnum.StartMenu:
                    PrintStartMenu();
                    break;
                default:
                    Console.WriteLine("nope");
                    break;
                
            }
        }

        private void PrintStartMenu()
        {
            Console.WriteLine("start menu");
        }
    }
}
