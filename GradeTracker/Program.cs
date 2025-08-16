using GradeTracker.Constants;
using GradeTracker.Methods;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization.Metadata;
using GradeTracker.Classes;

namespace GradeTracker
{
    internal class Program
    {
        //at the start i just shoved all my methods in this class
        //i felt super smart when i thought of making more classes just for methods lol
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<AClass> aClasses = new List<AClass>();
            List<Assignment> assignments = new List<Assignment>();

            students = Load.Students(students);
            aClasses = Load.AClasses(aClasses);
            assignments = Load.Assignments(assignments);

            Menu.Start(students, aClasses, assignments);
        }
    }
}