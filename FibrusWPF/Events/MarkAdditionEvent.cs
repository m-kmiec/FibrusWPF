using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibrusWPF.Events
{
    internal class MarkAdditionEvent
    {
        public int StudentId { get; set; }
        public string Mark { get; set; }
        public MarkAdditionEvent(int studentId, string mark)
        {
            StudentId = studentId;
            Mark = mark;
        }    
    }
}
