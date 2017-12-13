using Avalara.AvaTax.RestClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Tests.Avalara.AvaTax.RestClient.netstandard
{
    [TestFixture]
    public class NexusTests
    {
        public AvaTaxClient Client { get; set; }
        public string CompanyCode { get; set; }
        public CompanyModel TestCompany { get; set; }

        #region Setup / TearDown
        /// <summary>
        /// Create a company for use with these tests
        /// </summary>
        [SetUp]
        public void Setup()
        {
            try {
                // Create a client and set up authentication
                Client = new AvaTaxClient(typeof(TransactionTests).Name,
                    typeof(TransactionTests).GetTypeInfo().Assembly.ImageRuntimeVersion.ToString(),
                    Environment.MachineName,
                    AvaTaxEnvironment.Sandbox)
                    .WithSecurity(Environment.GetEnvironmentVariable("SANDBOX_USERNAME"), Environment.GetEnvironmentVariable("SANDBOX_PASSWORD"));

                // Verify that we can ping successfully
                var pingResult = Client.Ping();

                // Assert that ping succeeded
                Assert.NotNull(pingResult, "Should be able to call Ping");
                Assert.True(pingResult.authenticated, "Environment variables should provide correct authentication");

                // Create a basic company with nexus in the state of Washington
                TestCompany = Client.CompanyInitialize(new CompanyInitializationModel()
                {
                    city = "Bainbridge Island",
                    companyCode = Guid.NewGuid().ToString().Substring(0, 25),
                    country = "US",
                    email = "bob@example.org",
                    faxNumber = null,
                    firstName = "Bob",
                    lastName = "McExample",
                    line1 = "100 Ravine Lane",
                    mobileNumber = "206 555 1212",
                    phoneNumber = "206 555 1212",
                    postalCode = "98110",
                    region = "WA",
                    taxpayerIdNumber = "123456789",
                    name = "Bob's Greatest Popcorn",
                    title = "Owner/CEO"
                });

                // Assert that company setup succeeded
                Assert.NotNull(TestCompany, "Test company should be created");
                Assert.True(TestCompany.nexus.Count > 0, "Test company should have nexus");
                Assert.True(TestCompany.locations.Count > 0, "Test company should have locations");

                // Shouldn't fail
            } catch (Exception ex) {
                Assert.Fail("Exception in SetUp: " + ex.ToString());
            }
        }


        /// <summary>
        /// Any cleanup required goes here
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            try {

                // Re-fetch the company
                var company = Client.GetCompany(TestCompany.id, null);

                // Flag this company as inactive
                company.isActive = false;
                var disableResult = Client.UpdateCompany(company.id, company);

                // Assert that it succeeded
                Assert.NotNull(disableResult, "Should have been able to update this company");
                Assert.False(disableResult.isActive, "Company should have been deactivated");

                // Shouldn't fail
            } catch (Exception ex) {
                Assert.Fail("Exception in TearDown: " + ex.ToString());
            }
        }
        #endregion

        [Test]
        public void CreateAndDeleteNexus()
        {
            var nexusModels = new List<NexusModel>();

            var stateNexus = new NexusModel
            {
                id = 0,
                companyId = TestCompany.id,
                country = "US",
                region = "AL",
                jurisTypeId = JurisTypeId.STA,
                jurisCode = "01",
                jurisName = "ALABAMA",
                shortName = "AL",
                signatureCode = "",
                stateAssignedNo = "",
                nexusTypeId = NexusTypeId.SalesOrSellersUseTax,
                hasLocalNexus = true,
                hasPermanentEstablishment = true,
                effectiveDate = new DateTime(2008, 07, 01),
                endDate = new DateTime(2019, 07, 01)
            };

            var cityNexus = new NexusModel
            {
                id = 0,
                companyId = TestCompany.id,
                country = "US",
                region = "AL",
                jurisTypeId = JurisTypeId.CIT,
                jurisCode = "00124",
                jurisName = "ABBEVILLE",
                shortName = "ABBEVILLE",
                signatureCode = "",
                stateAssignedNo = "9356",
                nexusTypeId = NexusTypeId.SalesTax,
                hasLocalNexus = true,
                hasPermanentEstablishment = false,
                effectiveDate = new DateTime(2008, 07, 01),
                endDate = new DateTime(2018, 07, 01)
            };

            nexusModels.Add(stateNexus);
            nexusModels.Add(cityNexus);

            var nexusModelsAdded = Client.CreateNexus(TestCompany.id, new List<NexusModel> { stateNexus, cityNexus });

            // Get State nexus
            NexusModel getALNexus = null;
            try {
                getALNexus = Client.GetNexus(TestCompany.id, nexusModelsAdded[0].id);
            } catch (Exception) { }
            Assert.NotNull(getALNexus);

            var fetchedUSNexus = new List<NexusModel> { getALNexus };

            // Get City Nexus
            NexusModel getCityNexus = null;
            try {
                getCityNexus = Client.GetNexus(TestCompany.id, nexusModelsAdded[1].id);
            } catch (Exception) { }
            Assert.NotNull(getALNexus);

            fetchedUSNexus.Add(getCityNexus);

            // Delete Nexus
            var errorResult = Client.DeleteNexus(TestCompany.id, nexusModelsAdded[1].id);
            Assert.NotNull(errorResult);
        }
    }
}