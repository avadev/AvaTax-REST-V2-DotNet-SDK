using Avalara.AvaTax.RestClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avalara.AvaTax.RestClient.Test.net472
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
                Client = new AvaTaxClient(typeof(TransactionTests).Assembly.FullName,
                    typeof(TransactionTests).Assembly.GetName().Version.ToString(),
                    Environment.MachineName,
                    AvaTaxEnvironment.Sandbox)
                    .WithSecurity(Environment.GetEnvironmentVariable("SANDBOX_USERNAME"), Environment.GetEnvironmentVariable("SANDBOX_PASSWORD"));
                ApiCallLog.Attach(Client);

                // Verify that we can ping successfully
                var pingResult = Client.Ping();

                // Assert that ping succeeded
                Assert.NotNull(pingResult, "Should be able to call Ping");
                Assert.True(pingResult.authenticated, "Environment variables should provide correct authentication");

                // Create a basic company with nexus in the state of Washington
                TestCompany = TestCompanyFactory.Existing(Client) ?? Client.CompanyInitialize(new CompanyInitializationModel()
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

                // A reused company is not ours to deactivate
                if (TestCompanyFactory.IsReusing)
                {
                    return;
                }

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
                jurisdictionTypeId = JurisdictionType.State,
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
                jurisdictionTypeId = JurisdictionType.City,
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

            // The company can be shared with other suites and later runs, so make
            // sure these jurisdictions are clear before creating them.
            DeleteTestNexus();

            List<NexusModel> nexusModelsAdded = null;
            try
            {
                nexusModelsAdded = Client.CreateNexus(TestCompany.id, new List<NexusModel> { stateNexus, cityNexus });
                Assert.NotNull(nexusModelsAdded, "Nexus should have been created");
                Assert.AreEqual(2, nexusModelsAdded.Count, "Both nexus should have been created");

                // Get State nexus
                var getALNexus = Client.GetNexus(TestCompany.id, nexusModelsAdded[0].id.Value, null);
                Assert.NotNull(getALNexus, "Should have been able to fetch the state nexus");

                // Get City Nexus
                var getCityNexus = Client.GetNexus(TestCompany.id, nexusModelsAdded[1].id.Value, null);
                Assert.NotNull(getCityNexus, "Should have been able to fetch the city nexus");

                // Delete Nexus
                var errorResult = Client.DeleteNexus(TestCompany.id, nexusModelsAdded[1].id.Value, null);
                Assert.NotNull(errorResult);
            }
            finally
            {
                // Leave nothing behind, whatever happened above.
                DeleteTestNexus();
            }
        }

        /// <summary>
        /// Delete the nexus this test creates, when they are present. Called before
        /// the test so a company left dirty by an earlier run does not fail with
        /// DuplicateNexusError, and after it so this run leaves nothing behind.
        ///
        /// Cleanup is best effort: it must never replace the failure of the test
        /// itself, so problems are logged rather than thrown.
        /// </summary>
        private void DeleteTestNexus()
        {
            try
            {
                var existing = Client.ListNexusByCompany(TestCompany.id, null, null, null, null, null);
                if (existing == null || existing.value == null)
                {
                    return;
                }

                foreach (var nexus in existing.value)
                {
                    if (nexus.id == null || nexus.region != "AL")
                    {
                        continue;
                    }

                    if (nexus.jurisCode != "01" && nexus.jurisCode != "00124")
                    {
                        continue;
                    }

                    Client.DeleteNexus(TestCompany.id, nexus.id.Value, null);
                }
            }
            catch (AvaTaxError e)
            {
                TestContext.Progress.WriteLine("Could not clean up test nexus: " + ApiCallLog.Describe(e));
            }
        }
    }
}