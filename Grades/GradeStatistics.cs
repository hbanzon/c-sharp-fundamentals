using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeStatistics
    {
        public float HighestGrade { get; set; }
        public float LowestGrade { get; set; }
        public float Average { get; set; }
        public int NumberOfGrades { get; set; }

        public string LetterGrade
        {
            get
            {
                if (this.Average >= 90)
                    return "A";
                else if (this.Average >= 80)
                    return "B";
                else if (this.Average >= 70)
                    return "C";
                else if (this.Average >= 60)
                    return "D";
                else
                    return "F";
            }
        }

        public GradeStatistics()
        {
            this.HighestGrade = 0f;
            this.LowestGrade = float.MaxValue;
            this.Average = 0f;
            this.NumberOfGrades = 0;
        }

    }
}
