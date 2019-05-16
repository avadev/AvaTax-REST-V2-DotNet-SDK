using Avalara.AvaTax.RestClient;
using Avalara.AvaTax.RestClient.net45;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Avalara.AvaTax.RestClient.netstandard
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
            tr = await Client.TaxRatesByAddressAsync("100 Ravine Lane NE", null, null, "Bainbridge Island", "WA", "98110", "US");
            Assert.NotNull(tr);
            Assert.True(tr.totalRate > 0.05m);

            // By postal code for New York
            tr = await Client.TaxRatesByPostalCodeAsync("US", "10010");
            Assert.NotNull(tr);
            Assert.True(tr.totalRate > 0.05m);
        }

        /// <summary>
        /// Test the local rate by ZIP storage.
        /// </summary>        
        [Test]
        //[Ignore("This test will fail in Travis")]
        public void StoreRatesByZipTest()
        {
            string path = @"C:\git\develop\AvaTax-REST-V2-DotNet-SDK\src\taxRatesByZip\";
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
            var zipTaxRate = AvaTaxOfflineHelper.GetTaxRateByZip(zips[1], path);
            Assert.NotNull(zipTaxRate);
            decimal result = 9.99m * zipTaxRate.totalRate.Value;
            Assert.NotZero(result);
        }
    }
}
