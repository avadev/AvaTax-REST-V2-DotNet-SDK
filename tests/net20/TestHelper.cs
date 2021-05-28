using Avalara.AvaTax.RestClient;
using System;
#if PORTABLE
using System.Net.Http;
using System.Threading.Tasks;
#endif

namespace Tests.Avalara.AvaTax.RestClient.net20
{
    public class TestHelper
    {
#if PORTABLE
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
#endif
    }
}
