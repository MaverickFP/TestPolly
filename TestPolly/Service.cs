using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPolly
{
    public sealed class Service
    {
        private static Service  _instance;
        private int             counterInvoke = 0;

        private Service() { }

        public static Service Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Service();
                }
                return _instance;
            }
        }

        public void doOperation()
        {
            counterInvoke++;
            Console.WriteLine("Num of invoke: " + counterInvoke);
            throw new NotImplementedException("Not implemented method");
        }

    }
}
