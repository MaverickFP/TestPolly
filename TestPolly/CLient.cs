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
    /// <summary>
    /// Client class
    /// </summary>
    public class CLient
    {       
        //Singleton Service class
        private Service serviceClass;

        public CLient() 
        {
            serviceClass = Service.Instance;
        }


        /// <summary>
        /// Method for testing Polly
        /// </summary>
        public void callSomething()
        {   
            //Policy definition: 3 different types
            RetryPolicy policy = Policy.Handle<NotImplementedException>().Retry(5);
            //RetryPolicy policy = Policy.Handle<NotImplementedException>().WaitAndRetry(5, _ => TimeSpan.FromSeconds(10));
            //RetryPolicy policy = Policy.Handle<NotImplementedException>().WaitAndRetry(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1),5));

            //Apply policy to method call
            PolicyResult policyResult = policy.ExecuteAndCapture(() => serviceClass.doOperation());

            //check result
            if (String.IsNullOrEmpty(policyResult.FinalException?.ToString()))
            {
                Console.WriteLine("All ok");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        /// <summary>
        /// Call Service.doOperation without Polly
        /// </summary>
        public void callSomethingOld()
        {
            bool inError = true;
            while (inError)
            {
                try
                {
                    serviceClass.doOperation();
                    inError = false;
                }
                catch (NotImplementedException ex)
                {
                    inError = true;
                }
            }
        }


    }
}
