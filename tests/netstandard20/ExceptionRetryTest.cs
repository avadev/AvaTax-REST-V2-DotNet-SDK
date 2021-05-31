using Avalara.AvaTax.RestClient;
using NUnit.Framework;
using System;
using System.Net.Http;

namespace Tests.Avalara.AvaTax.RestClient.netstandard
{
    [TestFixture]
    public class ExceptionRetryTest
    {
        [Test]
        public void MethodExecutesOnce_MaxRetryAttempt_Zero_Test()
        {
            int maxRetryAttempts = 0;
            TestHelper testHelper = new TestHelper(maxRetryAttempts);
            Assert.ThrowsAsync<HttpRequestException>(async () => await testHelper.AddNonZeroIntegers(3, 0));
            Assert.AreEqual(1, testHelper.MethodCount);
        }

        [Test]
        public void MethodExecutes_FourTimes_MaxRetryAttempt_Three_Test()
        {
            int maxRetryAttempts = 3;
            TestHelper testHelper = new TestHelper(maxRetryAttempts);
            Assert.ThrowsAsync<HttpRequestException>(async () => await testHelper.AddNonZeroIntegers(3, 0));
            Assert.AreEqual(maxRetryAttempts + 1, testHelper.MethodCount);
        }

        [Test]
        public void Aggregate_Exception_Not_Following_RetryPolicy()
        {
            int maxRetryAttempts = 3;
            TestHelper testHelper = new TestHelper(maxRetryAttempts);
            Assert.ThrowsAsync<DivideByZeroException>(async () => await testHelper.DivideIntegers(3, 0));
            // As method is throwing DevideByZero Exception, method will execute only once even though maxRetryAttempt set to 3.
            Assert.AreEqual(1, testHelper.MethodCount);
        }

        [Test]
        public void UserConfiguration_test_MaxRetryAttempt_Three()
        {
            UserConfiguration userConfiguration = new UserConfiguration { MaxRetryAttempts = 3 };
            TestHelper testHelper = new TestHelper(userConfiguration);
            Assert.ThrowsAsync<HttpRequestException>(async () => await testHelper.AddNonZeroIntegers(3, 0));
            Assert.AreEqual(userConfiguration.MaxRetryAttempts + 1, testHelper.MethodCount);
        }

        [Test]
        public void UserConfiguration_test_MaxRetryAttempt_Negative()
        {
            UserConfiguration userConfiguration = new UserConfiguration { MaxRetryAttempts = -1 };
            TestHelper testHelper = new TestHelper(userConfiguration);
            Assert.ThrowsAsync<HttpRequestException>(async () => await testHelper.AddNonZeroIntegers(3, 0));
            Assert.AreEqual(0, userConfiguration.MaxRetryAttempts);
            Assert.AreEqual(userConfiguration.MaxRetryAttempts + 1, testHelper.MethodCount);
        }
    }
}