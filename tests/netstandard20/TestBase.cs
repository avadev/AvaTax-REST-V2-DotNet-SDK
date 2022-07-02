using Avalara.AvaTax.RestClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Avalara.AvaTax.RestClient.Test.netstandard20
{
    public class TestBase
    {
        protected AvaTaxClient _client;
        protected string _companyCode;
        protected CompanyModel _testCompany;

        [SetUp]
        public void Setup()
        {
            _client = null;
            _testCompany = null;
            try
            {
                // Create a client and set up authentication
                _client = new AvaTaxClient(GetType().Name,
                    GetType().GetTypeInfo().Assembly.ImageRuntimeVersion.ToString(),
                    Environment.MachineName,
                    AvaTaxEnvironment.Sandbox)
                    .WithSecurity(Environment.GetEnvironmentVariable("SANDBOX_USERNAME"), Environment.GetEnvironmentVariable("SANDBOX_PASSWORD"));

                // Verify that we can ping successfully
                var pingResult = _client.Ping();

                // Assert that ping succeeded
                Assert.NotNull(pingResult, "Should be able to call Ping");
                Assert.True(pingResult.authenticated, "Environment variables should provide correct authentication");

                _companyCode = Guid.NewGuid().ToString("N").Substring(0, 25);
                // Create a basic company with nexus in the state of Washington
                _testCompany = _client.CompanyInitialize(new CompanyInitializationModel()
                {
                    city = "Bainbridge Island",
                    companyCode = _companyCode,
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
                    name = "Bob's Hardware Store",
                    title = "Owner/CEO"
                });

                // Add a delay after creating a company
                System.Threading.Thread.Sleep(6 * 1000);

                // Assert that company setup succeeded
                Assert.NotNull(_testCompany, "Test company should be created");
                Assert.True(_testCompany.nexus.Count > 0, "Test company should have nexus");
                Assert.True(_testCompany.locations.Count > 0, "Test company should have locations");

                // Shouldn't fail
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
                // Re-fetch the company
                var company = _client.GetCompany(_testCompany.id, null);

                // Flag this company as inactive
                company.isActive = false;
                var disableResult = _client.UpdateCompany(company.id, company);

                // Assert that it succeeded
                Assert.NotNull(disableResult, "Should have been able to update this company");
                Assert.False(disableResult.isActive, "Company should have been deactivated");

                // Shouldn't fail
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception in TearDown: " + ex);
            }
        }
    }
}
