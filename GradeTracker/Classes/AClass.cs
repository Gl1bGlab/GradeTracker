using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using GradeTracker.Methods;

namespace GradeTracker.Classes
{
    public class AClass
    {
        //i'm sure it still looks really weird to you, but thinking of school subjects as "AClass" has become second nature to me
        //i also just kept it cuz it's funny
        public string Name {  get; set; }
        public int ID { get; set; }
        public List<Assignment> Assignments = new List<Assignment>();
        public List<Student> Students = new List<Student>();
        public double Grade { get; set; }
        public AClass(string name)
        {
            Name = name;
        }
        public AClass() { }
        public void SetID(List<AClass> aClasses)
        {
            List<int> ids = new List<int> {0};
            foreach (AClass c in aClasses)
            {
                ids.Add(c.ID);
            }
            int greatestID = ids.Last();
            ID = greatestID + 1;
        }
        public void AddAssignment(Assignment assignment)
        {
            Assignments.Add(assignment);
        }
        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }
        public void CalculateGrade()
        {
            double[] grades = new double[Assignments.Count];
            int gradesIndex = 0;
            foreach (Assignment a in Assignments)
            {
                grades[gradesIndex] = a.Grade;
                gradesIndex++;
            }
            Grade = grades.Average();
        }
        public void ListAssignments()
        {
            Console.WriteLine($"Assignments in {Name}");
            foreach (Assignment a in Assignments)
            { 
                Console.WriteLine(a.Name); 
                Console.WriteLine(a.Grade);
            }
        }
        public void WriteInfo()
        {
            Console.WriteLine();
            ListAssignments();
            Console.WriteLine($"Students in {Name}");
            foreach (Student s in Students)
                Console.WriteLine(s.Name);
        }
    }
}
