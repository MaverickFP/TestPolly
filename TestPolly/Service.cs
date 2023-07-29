using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPolly
{
    /// <summary>
    /// Singleton class: represents an external service. It is used to throw an exception and test Polly
    /// </summary>
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

        /// <summary>
        /// Fake method that throws an exception. The number of times it is invoked is counted.
        /// </summary>
        /// <exception cref="NotImplementedException">Exeception</exception>
        public void doOperation()
        {
            counterInvoke++;
            Console.WriteLine("Num of invoke: " + counterInvoke);
            throw new NotImplementedException("Not implemented method");
        }

    }
}
