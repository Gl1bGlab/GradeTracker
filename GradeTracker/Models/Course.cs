namespace GradeTracker.Models 
{
    public class Course 
    {
        public int Id { get; set;}
        public string Title { get; set;}
        public IEnumerable<Assignment> Assignments { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}