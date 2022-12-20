using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibrusWPF.Events
{
    internal class SubmitEvent
    {
        public string message { get; set; }

        public SubmitEvent(string message)
        {
            this.message = message;
        }
    }
}
