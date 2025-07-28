using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker
{
    public class AClass
    {
        private string Name {  get; set; }
        public List<Assignment> Assignments { get; set; }
        public AClass(string name) 
        {
            if (name != null)
            {
                this.Name = name.ToLower();
            }
        }
    }
}
