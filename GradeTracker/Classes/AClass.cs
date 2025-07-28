using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker
{
    public class AClass
    {
        public string Name {  get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Student> Students { get; set; }
        public AClass(string name) 
        {
            if (name != null)
            {
                this.Name = name.ToLower();
            }
        }
    }
}
