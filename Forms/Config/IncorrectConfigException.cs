using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration
{
    public class IncorrectConfigException : Exception
    {
        public IncorrectConfigException() { }
        public IncorrectConfigException(string message) : base(message) { }
    }
}
