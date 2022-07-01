using System;
using System.Collections.Generic;
using System.Text;

namespace VUV_PCSHOP
{
    class Exceptions : Exception
    {
        public Exceptions()
        {

        }
        public Exceptions(string message):base(message)
        {
            Console.WriteLine("Exception created.");
        }
        public Exceptions(string message,Exception inner):base(message,inner)
        {
            Console.WriteLine("Exception created.");
        }
    }
}
