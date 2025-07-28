using GradeTracker.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker
{
    public class Assignment
    {
        private int Grade { get; set; }
        private string Title { get; set; }
        private int Date { get; set; }
        private int MaxScore { get; set; }
        private string Name { get; set; }
        private AssignmentTypeEnum Type { get; set; }

        public Assignment(string assignmentName, AssignmentTypeEnum type)
        {
            this.Name = assignmentName.ToLower();
            Type = type;
        }
    }
}
