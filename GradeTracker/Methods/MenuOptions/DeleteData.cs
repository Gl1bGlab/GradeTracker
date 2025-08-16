using GradeTracker.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Methods.MenuOptions
{
    internal static class DeleteData
    {
//TODO: get rid of potential left over data
        //i've been so all over the place, i put this todo here like a week ago
        static public List<T> DeleteList<T>(List<T> list, string path, string type)
        {
            Console.WriteLine($"Are you sure you want to delete all {type} data? Y/N");
            bool conformation = false;
            while (!conformation)
            {
                string check = Console.ReadLine().ToLower();
                if (check == "y")
                {
                    DeletePath(path, type);
                    list = new List<T>();
                    conformation = true;
                }
                else if (check == "n")
                {
                    conformation = true;
                }
            }
            return list;
        }
        static public void DeletePath(string path, string type)
        {
            File.Delete(path);
            if (path == Paths.aClass)
            {
                File.Delete(Paths.assignment);
            }
            Console.WriteLine($"All {type} data has been deleted");
        }
    }
}
