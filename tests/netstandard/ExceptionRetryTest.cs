using NUnit.Framework;
using System;

namespace Tests.Avalara.AvaTax.netstandard11
{
    [TestFixture]
    public class ExceptionRetryTest
    {

        [Test]
        public void Exception_Retry_Zero_MaxAttempt()
        {
            int maxRetryAttempts = 0;
            TestHelper testHelper = new TestHelper(maxRetryAttempts);
            var result = testHelper.AddNonZeroIntegers(3, 0);
            Assert.AreEqual(maxRetryAttempts+1, testHelper.MethodCount);
        }

        [Test]
        public void Exception_Retry_Three_MaxAttempt()
        {
            int maxRetryAttempts = 3;
            TestHelper testHelper = new TestHelper(maxRetryAttempts);
            var result = testHelper.AddNonZeroIntegers(3, 0);
            Assert.AreEqual(maxRetryAttempts + 1, testHelper.MethodCount);

        }

        [Test]
        public void Aggregate_Exception_Not_Following_RetryPolicy()
        {
            int maxRetryAttempts = 3;
            TestHelper testHelper = new TestHelper(maxRetryAttempts);
            Assert.Throws<AggregateException>(()=>testHelper.DivideIntegers(3, 0));
            Assert.AreEqual(1, testHelper.MethodCount);

        }
    }
}
