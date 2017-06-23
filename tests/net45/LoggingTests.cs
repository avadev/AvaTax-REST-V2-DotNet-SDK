using Avalara.AvaTax.RestClient;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Avalara.AvaTax
{
    [TestFixture]
    public class LoggingTests
    {
        const int ACCOUNT_ID = 2000222644;
        const string LICENSE_KEY = "13BD79E8F5659D02B3A560DE214C53D60014213C";


        public AvaTaxClient Client { get; set; }
        public string CompanyCode { get; set; }
        public CompanyModel TestCompany { get; set; }
        public Mock<ILog> Logger { get; set; }
        public Action<LogEntry> LoggerCallback { get; set; }

        #region Setup / TearDown
        /// <summary>
        /// Create a company for use with these tests
        /// </summary>
        [SetUp]
        public void Setup()
        {
            try
            {
                Logger = new Mock<ILog>(MockBehavior.Strict);
                Logger.SetupGet(o => o.IsEnabled)
                    .Returns(() => true);

                LoggerCallback = (entry) => { };

                Logger.Setup(o => o.Write(It.IsAny<LogEntry>()))
                    .Callback<LogEntry>((data) => LoggerCallback(data));

                // Create a client and set up authentication
                Client = new AvaTaxClient(typeof(LoggingTests).Assembly.FullName,
                    typeof(LoggingTests).Assembly.GetName().Version.ToString(),
                    Environment.MachineName,
                    AvaTaxEnvironment.Sandbox)
                    //.WithSecurity(Environment.GetEnvironmentVariable("SANDBOX_USERNAME"), Environment.GetEnvironmentVariable("SANDBOX_PASSWORD"));
                    .WithSecurity(ACCOUNT_ID, LICENSE_KEY)
                    .WithLogging(Logger.Object);

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
                var company = Client.GetCompany(TestCompany.id, null);

                // Flag this company as inactive
                company.isActive = false;
                var disableResult = Client.UpdateCompany(company.id, company);

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
        #endregion



        [Test]
        public void Synchronous()
        {
            List<LogEntry> logged = new List<LogEntry>();
            LoggerCallback = (entry) =>
            {
                logged.Add(entry);
            };
            Logger.ResetCalls();
            // Execute a transaction
            var builder = new TransactionBuilder(Client, TestCompany.companyCode, DocumentType.SalesInvoice, "ABC")
                .WithAddress(TransactionAddressType.SingleLocation, "521 S Weller St", null, null, "Seattle", "WA",
                    "98104", "US")
                .WithLine(100.0m, 1, "P0000000")
                .WithLine(200m)
                .WithExemptLine(50m, "NT")
                .WithLineReference("Special Line Reference!", "Also this!");

            var model = builder.GetCreateTransactionModel();

            var transaction = Client.CreateTransaction(null, model);

            // Ensure this transaction was created, and has three lines, and has some tax
            Assert.NotNull(transaction, "Transaction should have been created");
            Assert.True(transaction.totalTax > 0.0m, "Transaction should have had some tax");
            Assert.True(transaction.lines.Count == 3, "Transaction should have three lines");
            Assert.True(transaction.lines[2].ref1.Contains("Reference!"), "Line3 should have had a Ref1.");

            Assert.AreEqual(1, logged.Count, "A single logged message should be returned");
            Assert.NotNull(logged.FirstOrDefault().Request, "Request Information is missing");
            Assert.AreEqual(2, logged.First().Request.Headers.Count, "Request: Expected 2 request headers");
            Assert.AreEqual("Post", logged.First().Request.Method, "Request: Expected Http Method to be Post");
            Assert.AreEqual("/api/v2/transactions/create", logged.First().Request.RequestUri.PathAndQuery, "Request uri is incorrect");
            Assert.AreSame(model, logged.First().Request.Body, "Request Body is not correct");
            Assert.NotNull(logged.First().Response, "Response Information is missing");
            Assert.AreEqual(8, logged.First().Response.Headers.Count, "Response: Expected 8 response headers");
            Assert.AreEqual(201, logged.First().Response.StatusCode, "Response: Expected a 201 status code");
            //Assert.AreEqual(13892, logged.First().Response.Body.Length, "Response Body is not the correct length");
            Logger.Verify(o => o.Write(It.IsAny<LogEntry>()), Times.Once);
        }

        [Test]
        public void Asynchronous()
        {
            Nito.AsyncEx.AsyncContext.Run(async () =>
            {
                List<LogEntry> logged = new List<LogEntry>();
                LoggerCallback = (entry) =>
                {
                    logged.Add(entry);
                };
                Logger.ResetCalls();
                // Execute a transaction
                var builder = new TransactionBuilder(Client, TestCompany.companyCode, DocumentType.SalesInvoice, "ABC")
                    .WithAddress(TransactionAddressType.SingleLocation, "521 S Weller St", null, null, "Seattle", "WA",
                        "98104", "US")
                    .WithLine(100.0m, 1, "P0000000")
                    .WithLine(200m)
                    .WithExemptLine(50m, "NT")
                    .WithLineReference("Special Line Reference!", "Also this!");
                    
                var model = builder.GetCreateTransactionModel();

                var transaction = await Client.CreateTransactionAsync(null, model);

                // Ensure this transaction was created, and has three lines, and has some tax
                Assert.NotNull(transaction, "Transaction should have been created");
                Assert.True(transaction.totalTax > 0.0m, "Transaction should have had some tax");
                Assert.True(transaction.lines.Count == 3, "Transaction should have three lines");
                Assert.True(transaction.lines[2].ref1.Contains("Reference!"), "Line3 should have had a Ref1.");

                Assert.AreEqual(1, logged.Count, "A single logged message should be returned");
                Assert.NotNull(logged.FirstOrDefault().Request, "Request Information is missing");
                Assert.AreEqual(2, logged.First().Request.Headers.Count, "Request: Expected 2 request headers");
                Assert.AreEqual("Post", logged.First().Request.Method, "Request: Expected Http Method to be Post");
                Assert.AreEqual("/api/v2/transactions/create", logged.First().Request.RequestUri.PathAndQuery, "Request uri is incorrect");
                Assert.AreEqual(model, logged.First().Request.Body, "Request Body is not correct");
                Assert.NotNull(logged.First().Response, "Response Information is missing");
                Assert.AreEqual(8, logged.First().Response.Headers.Count, "Response: Expected 8 response headers");
                Assert.AreEqual(201, logged.First().Response.StatusCode, "Response: Expected a 201 status code");
                //Assert.AreEqual(13892, logged.First().Response.Body.Length, "Response Body is not the correct length");
                Logger.Verify(o => o.Write(It.IsAny<LogEntry>()), Times.Once);
            });
        }
    }
}
