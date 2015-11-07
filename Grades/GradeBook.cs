using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        protected List<float> grades;

        protected string _name;
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!this._name.Equals(value, StringComparison.InvariantCultureIgnoreCase) && NameChanged != null)
                    {
                        var args = new NameChangedEventArgs();
                        args.NewName = value;
                        args.OldName = this._name;
                        NameChanged(this, args);
                    }
                    _name = value;
                }
            }
        }

        public event NameChangedDelegate NameChanged;

        public GradeBook() {
            this._name = "Empty";
            this.grades = new List<float>();
        }

        public void AddGrade(float grade)
        {
            this.grades.Add(grade);
        }

        public virtual GradeStatistics ComputeStatistics()
        {
            var stats = new GradeStatistics();
            var sum = 0f;
            foreach (float grade in grades)
            {
                sum += grade;
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
            }
            stats.Average = sum / this.grades.Count;
            stats.NumberOfGrades = grades.Count;
            return stats;
        }

    }
}
