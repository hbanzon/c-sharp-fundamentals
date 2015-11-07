using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker
    {
        protected List<float> _grades;

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
                        args.OldName = _name;
                        NameChanged(this, args);
                    }
                    _name = value;
                }
            }
        }

        public event NameChangedDelegate NameChanged;

        public abstract void AddGrade(float grade);

        public abstract GradeStatistics ComputeStatistics();

        public abstract IEnumerator GetEnumerator();
    }
}
