using System;

namespace Grades
{
    public class NameChangedEventArgs : EventArgs
    {
        public string OldName { get; set; }
        public string NewName { get; set; }
    }
}