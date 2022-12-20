using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibrusWPF.Events
{
    internal class DeletionEvent
    {
        public int Id { get; set; }

        public DeletionEvent(int id)
        {
            Id = id;
        }
    }
}
