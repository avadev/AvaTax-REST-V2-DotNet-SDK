using Avalara.AvaTax.RestClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Avalara.AvaTax.RestClient.netstandard;

namespace Tests.Avalara.AvaTax.netstandard
{
    [TestFixture]
    public class FreeTaxRatesTest
    {
        public AvaTaxClient Client { get; set; }

        #region Setup / Teardown
        /// <summary>
        /// Create a company for use with these tests
        /// </summary>
        [SetUp]
        public void Setup()
        {
            try {
                // Create a client and set up authentication
                Client = new AvaTaxClient(typeof(TransactionTests).Assembly.FullName,
                    typeof(TransactionTests).Assembly.GetName().Version.ToString(),
                    Environment.MachineName,
                    AvaTaxEnvironment.Sandbox)
                    .WithSecurity(Environment.GetEnvironmentVariable("SANDBOX_USERNAME"), Environment.GetEnvironmentVariable("SANDBOX_PASSWORD"));
            } catch (Exception ex) {
                Assert.Fail("Exception in SetUp: " + ex);
            }
        }
        #endregion

        [Test]
        public void TaxContentPullTest()
        {

        }
    }
}
