using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace GradeTracker
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<AClass> Classes { get; set; }
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
            Classes = new List<AClass>();
        }
        public Student(string name, int age, List<AClass> classes) => (Classes, Name, Age) = (classes, name, age);
        public Student() { }
        public void AddAClass(AClass aclass)
        {
            Classes.Add(aclass);
        }
        public override string ToString()
        {
            return this.Name + ", age " + this.Age + " years";
        }
    }
}
