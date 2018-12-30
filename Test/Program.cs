using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void fff()
        {
            Console.WriteLine("Я тест");
        }

        static void aaa()
        {
            Console.WriteLine("Я тест aaa");
        }

        static void Main(string[] args)
        {
            var t = new TestT();

            t.r += aaa;
            t.r += fff;

            t.exec();
        }
    }
}
