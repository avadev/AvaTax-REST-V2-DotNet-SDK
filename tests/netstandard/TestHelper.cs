using Avalara.AvaTax.RestClient;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests.Avalara.AvaTax.netstandard11
{
    public class TestHelper
    {
        private int maxRetryAttempts;
        private ExceptionRetry _exceptionRetry; 

        public TestHelper(int _maxRetryAttempt)
        {
            maxRetryAttempts = _maxRetryAttempt;
            _exceptionRetry = new ExceptionRetry(maxRetryAttempts);
        }
        public int MethodCount { get; set; }
        
        public int AddNonZeroIntegers(int a, int b)
        { 
            return _exceptionRetry.RetryPolicy.ExecuteAsync(async () =>
            {
                await Task.Delay(1);
                MethodCount++;
                if (b == 0 && MethodCount <= maxRetryAttempts)
                {
                    throw new HttpRequestException("0 is not allowed");
                }
                else
                {
                    return a + b;
                }
            }).Result;
        }

        public int DivideIntegers(int a, int b)
        {
            return _exceptionRetry.RetryPolicy.ExecuteAsync(async () =>
            {
                await Task.Delay(1);
                MethodCount++;
                if (b == 0 && MethodCount <= maxRetryAttempts)
                {
                    throw new DivideByZeroException();
                }
                else
                {
                    return a/b;
                }
            }).Result;
        }
    }
}
