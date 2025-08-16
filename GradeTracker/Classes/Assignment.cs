using GradeTracker.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using GradeTracker.Methods;
using System.Net;

namespace GradeTracker.Classes
{
    public class Assignment
    {
        //actually grading stuff is still a relativly recent addition, so don't be too suprised if it's put together really badly
        //compared to the rest of my code anyway lol
        public int ID { get; set; }
        public double Grade { get; set; }
        public double AverageGrade { get; set; }
        private DateTime Date { get; set; }
        private int MaxScore { get; set; }
        public bool IsGraded = false;
        public string Name { get; set; }
        public int AClassID { get; set; }
        private AssignmentTypeEnum Type { get; set; }
        public Assignment(string name, AssignmentTypeEnum type, int maxScore,  DateTime date, int aClassID)
        {
            Name = name;
            Type = type;
            MaxScore = maxScore;
            Date = date;
            AClassID = aClassID;
        }
        public Assignment() { }
        public void SetID(List<Assignment> assignments)
        {
            List<int> ids = new List<int> {0};
            foreach (Assignment a in assignments)
            {
                ids.Add(a.ID);
            }
            int greatestID = ids.Last();
            ID = greatestID + 1;
        }
        public void Grading()
        {
            double grade = 0;
            bool validGrade = false;
            while (!validGrade)
            {
                grade = Find.WriteAnIntDummy();
                if (grade < 0)
                {
                    Console.WriteLine("Grade cannot be less than 0");
                }
                else
                {
                    validGrade = true;
                }
            }
            Grade = grade;
            IsGraded = true;
        }
        public void WriteInfo(bool extraInfo)
        {
            Console.WriteLine($"\nName: {Name}\nMax score: {MaxScore}");
            if (extraInfo)
            {
                if (IsGraded)
                    Console.WriteLine($"Grade: {Grade}");
                else
                    Console.WriteLine("Grade: Not yet graded");
                Console.WriteLine($"Average grade: {AverageGrade}");
                Console.WriteLine($"Date & time of creation: {Date}");
            }
            Console.WriteLine($"ID: {ID}");
        }
        public void CalculateAverageGrade(List<Student> students)
        {
            List<double> grades = new List<double>();
            foreach (Student s in students)
            {
                foreach (AClass c in s.AClasses)
                {
                    if (c.ID == ID)
                    {
                        Assignment assignmentCopy = c.Assignments.First(a => a.ID == ID);
                        grades.Add(assignmentCopy.Grade);
                    }
                }
            }
            if (grades.Any())
                AverageGrade = grades.Average();
            else
                AverageGrade = 0;
        }
    }
}
