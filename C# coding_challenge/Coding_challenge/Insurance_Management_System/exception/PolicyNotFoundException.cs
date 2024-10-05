using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Management_System.exception
{
    internal class PolicyNotFoundException : Exception
    {
        public PolicyNotFoundException()
        {
        }

        public PolicyNotFoundException(string message)
            : base(message)
        {
        }
        public PolicyNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
        public override string ToString()
        {
            return $"PolicyNotFoundException: {Message}";
        }
    }
}
