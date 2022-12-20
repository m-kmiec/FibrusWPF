using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibrusWPF.Events
{
    internal class SubmitEvent
    {
        public SubmitEvent(string firstName, string lastName, string studentClass, string marks)
        {
            FirstName = firstName;
            LastName = lastName;
            StudentClass = studentClass;
            Marks = marks;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentClass { get; set; }
        public string Marks { get; set; }

     
    }
}
