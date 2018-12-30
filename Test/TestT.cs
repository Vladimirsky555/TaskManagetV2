using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TestT
    {
        public delegate void test();
        public event test r;

        //private List<test> d = new List<test>();

        //public void subscribe(test e)
        //{
        //    d.Add(e);
        //}

        //public void unsubscribe(test e)
        //{
        //    d.Remove(e);
        //}

        public void exec()
        {
            //foreach (var e in d)
            //    e();

            r();
        }
    }
}
