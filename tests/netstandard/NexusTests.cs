using Avalara.AvaTax.RestClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Avalara.AvaTax.RestClient.Test.netstandard
{
    [TestFixture]
    [Ignore("This test is not yet implemented")]
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
                nexusModelsAdded = CreateTestNexus(stateNexus, cityNexus);
                Assert.NotNull(nexusModelsAdded, "Nexus should have been created");
                Assert.AreEqual(2, nexusModelsAdded.Count, "Both nexus should have been created");

                // Get State nexus
                var getALNexus = FetchNexus(nexusModelsAdded[0].id.Value);
                Assert.NotNull(getALNexus, "Should have been able to fetch the state nexus");

                // Get City Nexus
                var getCityNexus = FetchNexus(nexusModelsAdded[1].id.Value);
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
        /// Attempts allowed when a jurisdiction still looks occupied.
        /// </summary>
        private const int CreateAttempts = 3;

        /// <summary>
        /// Attempts allowed when fetching a nexus that was just created.
        /// </summary>
        private const int FetchAttempts = 5;

        /// <summary>
        /// Milliseconds to wait between attempts.
        /// </summary>
        private const int RetryDelayMilliseconds = 2 * 1000;

        /// <summary>
        /// Create the two nexus, retrying past DuplicateNexusError.
        ///
        /// The nexus list can serve a stale read, so cleanup can find nothing to
        /// remove while the entries are in fact still there. Clearing again after a
        /// pause is the only way to tell a genuine duplicate from a stale list.
        /// </summary>
        /// <param name="stateNexus">State nexus to create.</param>
        /// <param name="cityNexus">City nexus to create.</param>
        private List<NexusModel> CreateTestNexus(NexusModel stateNexus, NexusModel cityNexus)
        {
            for (var attempt = 1; ; ++attempt)
            {
                try
                {
                    return Client.CreateNexus(TestCompany.id, new List<NexusModel> { stateNexus, cityNexus });
                }
                catch (AvaTaxError e)
                {
                    if (attempt >= CreateAttempts || !IsDuplicateNexus(e))
                    {
                        throw;
                    }

                    TestContext.Progress.WriteLine($"Nexus still present on attempt {attempt}, "
                        + "clearing and retrying: " + ApiCallLog.Describe(e));
                    System.Threading.Thread.Sleep(RetryDelayMilliseconds);
                    DeleteTestNexus();
                }
            }
        }

        /// <summary>
        /// Fetch a nexus, allowing for the read lag that can leave one that was just
        /// created briefly invisible. Returns null once the attempts run out, so the
        /// caller's assertion is what reports the failure.
        /// </summary>
        /// <param name="nexusId">Nexus to fetch.</param>
        private NexusModel FetchNexus(Int32 nexusId)
        {
            for (var attempt = 1; attempt <= FetchAttempts; ++attempt)
            {
                try
                {
                    var nexus = Client.GetNexus(TestCompany.id, nexusId, null);
                    if (nexus != null)
                    {
                        return nexus;
                    }

                    TestContext.Progress.WriteLine($"Nexus {nexusId} fetched as null on attempt {attempt}.");
                }
                catch (AvaTaxError e)
                {
                    TestContext.Progress.WriteLine($"Nexus {nexusId} not fetchable on attempt {attempt}: "
                        + ApiCallLog.Describe(e));
                }

                System.Threading.Thread.Sleep(RetryDelayMilliseconds);
            }

            return null;
        }

        /// <summary>
        /// True when the error says the nexus already exists.
        /// </summary>
        /// <param name="error">Error to inspect.</param>
        private static bool IsDuplicateNexus(AvaTaxError error)
        {
            return error != null
                && error.error != null
                && error.error.error != null
                && error.error.error.code == ErrorCodeId.DuplicateNexusError;
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
            FetchResult<NexusModel> existing;
            try
            {
                existing = Client.ListNexusByCompany(TestCompany.id, null, null, null, null, null);
            }
            catch (AvaTaxError e)
            {
                TestContext.Progress.WriteLine("Could not list nexus to clean up: " + ApiCallLog.Describe(e));
                return;
            }

            if (existing == null || existing.value == null)
            {
                return;
            }

            // The city nexus is a child of the state nexus, and AvaTax refuses to
            // delete a parent while a child exists, so take the local jurisdiction
            // first. cascadeDelete covers any child this test does not know about.
            foreach (var jurisCode in new[] { "00124", "01" })
            {
                foreach (var nexus in existing.value)
                {
                    if (nexus.id == null || nexus.region != "AL" || nexus.jurisCode != jurisCode)
                    {
                        continue;
                    }

                    try
                    {
                        Client.DeleteNexus(TestCompany.id, nexus.id.Value, true);
                    }
                    catch (AvaTaxError e)
                    {
                        // Keep going: one stale entry must not leave the rest behind.
                        TestContext.Progress.WriteLine($"Could not delete nexus {nexus.id} "
                            + $"({nexus.region}/{nexus.jurisCode}): " + ApiCallLog.Describe(e));
                    }
                }
            }
        }
    }
}