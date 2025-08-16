using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Bson;
using GradeTracker.Methods;

namespace GradeTracker.Classes
{
    public class Student
    {
        //no clue if i'm setting up non-static classes right at all, but they seem to be working ok for now
        //i'm excited to see how you put this kinda stuff together in your version, cuz this kinda stuff always feels like a mess when i'm making it
        public string Name { get; set; }
        public int Age { get; set; }
        public List<AClass> AClasses { get; set; }
        public int ID { get; set; }
        public double TotalGrade { get; set; }
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
            AClasses = new List<AClass>();
        }
        public Student(string name, int age, List<AClass> classes) => (AClasses, Name, Age) = (classes, name, age);
        public Student() { }
        public void AddAClass(AClass aClass)
        {
            AClasses.Add(aClass);
        }
        public void RemoveAClass(AClass aClass)
        {
            AClasses.Remove(aClass);
        }
        public void GradeAssignment(int assignmentID)
        {
            bool found = false;
            foreach (AClass c in AClasses)
            {
                foreach (Assignment a in c.Assignments)
                {
                    if (a.ID == assignmentID)
                    {
                        c.Assignments.Remove(a);
                        a.Grading();
                        c.Assignments.Add(a);
                        c.CalculateGrade();
                        CalculateTotalGrade();
                        found = true;
                    }
                    if (found) { break; }
                }
                if (found) { break; }
            }
        }
        public void SetID(List<Student> students)
        {
            List<int> ids = new List<int> {0};
            foreach (Student s in students)
            {
                ids.Add(s.ID);
            }
            int greatestID = ids.Last();
            ID = greatestID + 1;
        }
        public void CalculateTotalGrade()
        {
            double[] classGrades = new double[AClasses.Count];
            int classGradesIndex = 0;

            foreach (AClass c in AClasses)
            {
                classGrades[classGradesIndex] = c.Grade;
                classGradesIndex++;
            }

            TotalGrade = Convert.ToDouble(classGrades.Average());
        }
        public void WriteInfo()
        {
            Console.WriteLine($"\nAge: {Age}\nCurrent subjects:");
            if (Checks.IfAny(AClasses, "enrolled subjects"))
            {
                foreach (AClass c in AClasses)
                {
                    Console.WriteLine(c.Name);
                    Console.WriteLine($"{c.Name} grade: {c.Grade}\n");
                    foreach(Assignment a in c.Assignments)
                    {
                        a.WriteInfo(true);
                    }
                }
            }
            Console.WriteLine($"Total grade: {TotalGrade}\n");
        }
    }
}
