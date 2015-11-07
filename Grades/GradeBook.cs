using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        public GradeBook() {
            this._name = "Empty";
            this._grades = new List<float>();
        }

        public override void AddGrade(float grade)
        {
            this._grades.Add(grade);
        }

        public override GradeStatistics ComputeStatistics()
        {
            var stats = new GradeStatistics();
            var sum = 0f;
            foreach (float grade in this)
            {
                sum += grade;
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
            }
            stats.Average = sum / this._grades.Count;
            stats.NumberOfGrades = this._grades.Count;
            return stats;
        }

        public override IEnumerator GetEnumerator()
        {
            return this._grades.GetEnumerator();
        }
    }
}
