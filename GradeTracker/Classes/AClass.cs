using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using GradeTracker.Methods;

namespace GradeTracker
{
    public class AClass
    {
        public string Name {  get; set; }
        public List<Assignment> Assignments = new List<Assignment>();
        public List<Student> Students = new List<Student>();
        public AClass(string name)
        {
            Name = name;
        }
        public AClass(string name, List<Assignment> assignments, List<Student> students) => (Name, Assignments, Students) = (name, assignments, students);
        public AClass() { }
        public void AddAssignment(Assignment assignment)
        {
            Assignments.Add(assignment);
        }
        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
        public void ListAssignments()
        {
            Console.WriteLine($"Assignments in {Name}");
            foreach (Assignment a in Assignments)
            { Console.WriteLine(a.Name); }
        }
    }
}
