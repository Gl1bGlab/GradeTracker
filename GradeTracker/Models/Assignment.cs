using GradeTracker.Constants;

namespace GradeTracker.Models 
{
    public class Assignment 
    {
        public string Title { get; set;}
        public AssignmentTypeEnum Type { get; set; }
        public int MaxScore { get; set; }
        public int ScoreEarned { get; set; }
        public DateTime Date { get; set; }
    }
}