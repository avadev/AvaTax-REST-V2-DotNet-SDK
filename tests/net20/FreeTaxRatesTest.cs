using Avalara.AvaTax.RestClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace Tests.Avalara.AvaTax.RestClient.net20
{
    [TestFixture]
    class FreeTaxRatesTest
    {
        public AvaTaxClient _client;

        #region Setup / Teardown
        /// <summary>
        /// Create a company for use with these tests
        /// </summary>
        [SetUp]
        public void Setup()
        {
            try {
                // Create a client and set up authentication
                _client = new AvaTaxClient(typeof(FreeTaxRatesTest).Assembly.FullName,
                    typeof(FreeTaxRatesTest).Assembly.GetName().Version.ToString(),
                    Environment.MachineName,
                    AvaTaxEnvironment.Sandbox)
                    .WithSecurity(Environment.GetEnvironmentVariable("SANDBOX_USERNAME"), Environment.GetEnvironmentVariable("SANDBOX_PASSWORD"));
            } catch (Exception ex) {
                Assert.Fail("Exception in SetUp: " + ex);
            }
        }
        #endregion

        [Test]
        public void FreeTaxRates()
        {
            // Call TaxRates for a few addresses and verify that the rates are nonzero
            var tr = _client.TaxRatesByAddress("123 Main Street", null, null, "Irvine", "CA", "92615", "US");
            Assert.NotNull(tr);
            Assert.True(tr.totalRate > 0.05m);

            // Washington
            tr = _client.TaxRatesByAddress("100 Ravine Lane NE", null, null, "Bainbridge Island", "WA", "98110", "US");
            Assert.NotNull(tr);
            Assert.True(tr.totalRate > 0.05m);

            // By postal code for New York
            tr = _client.TaxRatesByPostalCode("US", "10010");
            Assert.NotNull(tr);
            Assert.True(tr.totalRate > 0.05m);
        }

        /// <summary>
        /// Test the local rate by ZIP storage and retrieval.
        /// </summary>        
        [Test]
        [Ignore("This test will fail in Travis")]
        public void StoreRatesByZipTest()
        {
            string path = Environment.GetEnvironmentVariable("ZIP_RATE_FILE_STORAGE_PATH");
            List<string> zips = new List<string>() { "12590", "98104" };

            //Call the content caching helper.
            AvaTaxOfflineHelper.StoreZipRateContent(_client, "US", zips, path);

            //Verify that the file was stored locally. 
            bool zipRateExists = AvaTaxOfflineHelper.VerifyLocalZipRateAvailable(zips[1], path);
            Assert.True(zipRateExists);


            //Verify that a bogus file does not exist locally.
            zipRateExists = AvaTaxOfflineHelper.VerifyLocalZipRateAvailable("bogusZipFile.json", path);
            Assert.False(zipRateExists);

            //Verify that the local file can be used for rate calculation.
            var zipTaxRate = AvaTaxOfflineHelper.GetTaxRateByZip(zips[1], path);
            Assert.NotNull(zipTaxRate);
            decimal result = 9.99m * zipTaxRate.totalRate.Value;
            Assert.NotZero(result);
        }
    }
}
