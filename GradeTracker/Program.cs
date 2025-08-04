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

namespace GradeTracker
{
    internal class Program
    {
        static void Save(List<Student> students, List<AClass> aClasses, List<Assignment> assignments)
        {
            if (students.Any())
            {
                string cerialStudents = JsonSerializer.Serialize(students);
                File.WriteAllText(Paths.student , cerialStudents);
            }
            if (aClasses.Any())
            {
                string cerialAClasses = JsonSerializer.Serialize(aClasses);
                File.WriteAllText(Paths.aClass, cerialAClasses);
            }
            if(assignments.Any())
            {
                string cerialAssignments = JsonSerializer.Serialize(assignments);
                File.WriteAllText(Paths.assignment, cerialAssignments);
            }
        }
        
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<AClass> aClasses = new List<AClass>();
            List<Assignment> assignments = new List<Assignment>();

            students = Load.Students(students);
            aClasses = Load.AClasses(aClasses);
            assignments = Load.Assignments(assignments);

            Menu.Start(students, aClasses, assignments);

            Save(students, aClasses, assignments);
        }
    }
}