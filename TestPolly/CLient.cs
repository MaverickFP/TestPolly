using Polly.Retry;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polly.Contrib.WaitAndRetry;

namespace TestPolly
{
    public class CLient
    {       
        private Service serviceClass;

        public CLient() 
        {
            serviceClass = Service.Instance;
        }


        public void callSomething()
        {            
            
            RetryPolicy policy = Policy.Handle<NotImplementedException>().Retry(5);
            //RetryPolicy policy = Policy.Handle<NotImplementedException>().WaitAndRetry(5, _ => TimeSpan.FromSeconds(10));
            //RetryPolicy policy = Policy.Handle<NotImplementedException>().WaitAndRetry(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1),5));

            PolicyResult policyResult = policy.ExecuteAndCapture(() => serviceClass.doOperation());

            if (String.IsNullOrEmpty(policyResult.FinalException?.ToString()))
            {
                Console.WriteLine("All ok");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }


    }
}
