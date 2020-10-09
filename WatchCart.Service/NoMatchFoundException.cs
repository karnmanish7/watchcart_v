using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchCart.Service
{
    public class NoMatchFoundException : Exception
    {
        public NoMatchFoundException()
        {
        }

        public NoMatchFoundException(string message) : base(message)
        {
        }
    }
}
