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

        public TestHelper(UserConfiguration userConfiguration)
        {
            _exceptionRetry = new ExceptionRetry(userConfiguration.MaxRetryAttempts);
        }

        public int MethodCount { get; set; }
        
        public async Task AddNonZeroIntegers(int a, int b)
        { 
            await _exceptionRetry.RetryPolicy.ExecuteAsync(async () =>
            {
                await Task.Delay(1);
                MethodCount++;
                if (b == 0)
                {
                    throw new HttpRequestException("0 is not allowed");
                }
                else
                {
                    return a + b;
                }
            });
        }

        public async Task DivideIntegers(int a, int b)
        {
            await _exceptionRetry.RetryPolicy.ExecuteAsync(async () =>
            {
                await Task.Delay(1);
                MethodCount++;
                if (b == 0)
                {
                    throw new DivideByZeroException();
                }
                else
                {
                    return a/b;
                }
            });
        }
#endif
    }
}
