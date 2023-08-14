using Avalara.AvaTax.RestClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Avalara.AvaTax.RestClient.Test.net45
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
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                // Create a client and set up authentication
                Client = new AvaTaxClient(typeof(FreeTaxRatesTest).Assembly.FullName,
                    typeof(FreeTaxRatesTest).Assembly.GetName().Version.ToString(),
                    Environment.MachineName,
                    AvaTaxEnvironment.Sandbox)
                    .WithSecurity(Environment.GetEnvironmentVariable("SANDBOX_USERNAME"), Environment.GetEnvironmentVariable("SANDBOX_PASSWORD"));

                
            } catch (Exception ex) {
                Assert.Fail("Exception in SetUp: " + ex);
            }
        }
        #endregion

        /// <summary>
        ///   <para>
        ///  Test that the SDK can pull tax rate objects.
        /// </para>
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task FreeTaxRates()
        {
            // Call TaxRates for a few addresses and verify that the rates are nonzero
            var tr = await Client.TaxRatesByAddressAsync("123 Main Street", null, null, "Irvine", "CA", "92615", "US");
            Assert.NotNull(tr);
            Assert.True(tr.totalRate > 0.05m);

            // Washington
            tr = await Client.TaxRatesByAddressAsync("522 Stadium Pl S", null, null, "Seattle", "WA", "98104", "US");
            Assert.NotNull(tr);
            Assert.True(tr.totalRate > 0.05m);

            // By postal code for New York
            tr = await Client.TaxRatesByPostalCodeAsync("US", "10010");
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
            AvaTaxOfflineHelper.StoreZipRateContent(Client, "US", zips, path);

            //Verify that the file was stored locally. 
            bool zipRateExists = AvaTaxOfflineHelper.VerifyLocalZipRateAvailable(zips[1], path);
            Assert.True(zipRateExists);


            //Verify that a bogus file does not exist locally.
            zipRateExists = AvaTaxOfflineHelper.VerifyLocalZipRateAvailable("bogusZipFile.json", path);
            Assert.False(zipRateExists);

            //Verify that the local file can be used for rate calculation.
            var zipTaxRate = AvaTaxOfflineHelper.GetLocalTaxRateByZip(zips[1], path);
            Assert.NotNull(zipTaxRate);
            decimal result = 9.99m * zipTaxRate.totalRate.Value;
            Assert.NotZero(result);

            //Test AvaTaxOfflineHelper Exception handling.
            path = @"n:\someBadPath";
            try {
                AvaTaxOfflineHelper.StoreZipRateContent(Client, "US", zips, path);
            } catch (AvaTaxOfflineHelperException exc) {
#if PORTABLE
                Assert.True(string.Equals(exc.InnerException.Message, "Could not find a part of the path 'n:\\someBadPath\\12590.json'."));
#else
                Assert.True(string.Equals(exc.Message, "An error occurred retrieving or storing the rate content. Please see inner exception for details."));
#endif
            }
        }
    }
}
