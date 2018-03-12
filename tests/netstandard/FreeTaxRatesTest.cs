using Avalara.AvaTax.RestClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Avalara.AvaTax.RestClient.netstandard
{
    class FreeTaxRatesTest
    {
        [Test]
        public async Task FreeTaxRates()
        {
            // Create a client and set up authentication
            var client = new AvaTaxClient(typeof(TransactionTests).Name,
                typeof(TransactionTests).GetTypeInfo().Assembly.ImageRuntimeVersion.ToString(),
                Environment.MachineName,
                AvaTaxEnvironment.Sandbox)
                .WithSecurity(Environment.GetEnvironmentVariable("SANDBOX_USERNAME"), Environment.GetEnvironmentVariable("SANDBOX_PASSWORD"));

            // Call TaxRates for a few addresses and verify that the rates are nonzero
            var tr = await client.TaxRatesByAddress("123 Main Street", null, null, "Irvine", "CA", "92615", "US");
            Assert.NotNull(tr);
            Assert.True(tr.totalRate > 0.05m);

            // Washington
            tr = await client.TaxRatesByAddress("100 Ravine Lane NE", null, null, "Bainbridge Island", "WA", "98110", "US");
            Assert.NotNull(tr);
            Assert.True(tr.totalRate > 0.05m);

            // By postal code for New York
            tr = await client.TaxRatesByPostalCode("US", "10010");
            Assert.NotNull(tr);
            Assert.True(tr.totalRate > 0.05m);
        }
    }
}
