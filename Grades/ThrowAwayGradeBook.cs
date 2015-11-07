using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class ThrowAwayGradeBook : GradeBook
    {
        public override GradeStatistics ComputeStatistics()
        {
            // find and throw away lowest grade
            if (this.grades.Count > 0)
            {
                var lowestGrade = float.MaxValue;
                foreach (float grade in this.grades)
                {
                    lowestGrade = Math.Min(grade, lowestGrade);
                }
                this.grades.Remove(lowestGrade);
            }

            // proceed with rest of compute logic
            return base.ComputeStatistics();
        }
    }
}
