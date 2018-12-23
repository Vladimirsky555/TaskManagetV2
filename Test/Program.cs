using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = DateTime.Now.AddSeconds(10);
            var n = d - DateTime.Now;

            Console.WriteLine(n.TotalSeconds);
        }
    }
}
