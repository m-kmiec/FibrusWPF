using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibrusWPF.Events
{
    internal class StudentDeletionEvent
    {
        public int Id { get; set; }

        public StudentDeletionEvent(int id)
        {
            Id = id;
        }
    }
}
