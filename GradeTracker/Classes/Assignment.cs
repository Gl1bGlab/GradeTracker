using GradeTracker.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace GradeTracker
{
    public class Assignment
    {
        private int Grade { get; set; }
        private DateTime Date { get; set; }
        private int MaxScore { get; set; }
        public bool isAssigned = false;
        public string Name { get; set; }
        public string AClassName = "";
        private AssignmentTypeEnum Type { get; set; }
        public Assignment(string Name, AssignmentTypeEnum Type, int MaxScore,  DateTime Date, int Grade)
        {
            this.Name = Name;
            this.Type = Type;
            this.MaxScore = MaxScore;
            this.Date = Date;
            this.Grade = Grade;
        }
        public Assignment(string Name, AssignmentTypeEnum Type, int MaxScore, string AClassName, DateTime Date, int Grade)
        {
            this.Name = Name;
            this.Type = Type;
            this.MaxScore = MaxScore;
            this.Date = Date;
            this.AClassName = AClassName;
            this.Grade = Grade;
        }
        public Assignment() { }
        public void AssignToAClass(string aClassName)
        {
            AClassName = aClassName;
            isAssigned = true;
        }
        public void Grading()
        {
            Grade = Convert.ToInt32(Console.ReadLine());
        }
    }
}
