using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibrusWPF.Events
{
    internal class MarkDeletionEvent
    {
        public MarkDeletionEvent(int studentId, string mark)
        {
            StudentId = studentId;
            Mark = mark;
        }

        public int StudentId { get; set; }

        public string Mark { get; set; }
    }
}
