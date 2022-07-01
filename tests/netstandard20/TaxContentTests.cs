using Avalara.AvaTax.RestClient;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace Tests.Avalara.AvaTax.RestClient.netstandard
{
    [TestFixture]
    public class TaxContentTests
    {
        public AvaTaxClient Client { get; set; }
        public string CompanyCode { get; set; }
        public int DefaultCompanyId { get; set; }
        public CompanyModel TestCompany { get; set; }

        #region Setup / TearDown
        /// <summary>
        /// Create a company for use with these tests
        /// </summary>
        [SetUp]
        public void Setup()
        {
            try
            {
                // Create a client and set up authentication
                Client = new AvaTaxClient(typeof(TaxContentTests).Name,
                    typeof(TaxContentTests).GetTypeInfo().Assembly.ImageRuntimeVersion.ToString(),
                    Environment.MachineName,
                    AvaTaxEnvironment.Sandbox).WithSecurity("demo.compliance-verification", "sxgv7KK4HX*B7vY@");
                    //.WithSecurity(Environment.GetEnvironmentVariable("SANDBOX_USERNAME"), Environment.GetEnvironmentVariable("SANDBOX_PASSWORD"));
                ////Get the default company.
                //var defaultCompanyModel = Client.QueryCompanies(string.Empty, "isDefault EQ true", null, null, string.Empty).value[0];
                //DefaultCompanyId = defaultCompanyModel.id;

            }
            catch (Exception ex)
            {
                Assert.Fail("Exception in SetUp: " + ex);
            }
        }


        /// <summary>
        /// Any cleanup required goes here
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            try
            {

                //// Re-fetch the company
                //var company = Client.GetCompany(TestCompany.id, null);

                //// Flag this company as inactive
                //company.isActive = false;
                //var disableResult = Client.UpdateCompany(company.id, company);

                //// Assert that it succeeded
                //Assert.NotNull(disableResult, "Should have been able to update this company");
                //Assert.False(disableResult.isActive, "Company should have been deactivated");

                // Shouldn't fail
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception in TearDown: " + ex);
            }
        }
        #endregion

        /// <summary>
        /// Tests the upload certificate image endpoint.
        /// </summary>
        [Test]
        public async Task DownloadPointOfSaleTest()
        {
            try
            {
                //var result = Client.BuildTaxContentFileForLocation(2183654, 2006110, null, PointOfSaleFileType.Csv, null, null);
                //var result = await Client.BuildTaxContentFileForLocationAsync(2183654, 2006110, null, PointOfSaleFileType.Csv, null, null);
                var result = await Client.DownloadTaxRatesByZipCodeAsync(DateTime.Now, null);
                //var result = Client.DownloadTaxRatesByZipCode(DateTime.Now, null);
                Assert.NotNull(result.Data);
            } 
            catch (Exception ex)
            {
                Assert.Fail("Exception in DownloadPointOfSale: " + ex);
            }
         
            //Assert.True(string.Equals(certAttachment.ContentType, "application/pdf"));
            //Assert.True(certAttachment.Data.Length > 1000);

        }
    }
}