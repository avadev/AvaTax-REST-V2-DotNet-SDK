using Avalara.AvaTax.RestClient;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace Avalara.AvaTax.RestClient.Test.netstandard20
{
    [TestFixture]
    public class TransactionTests
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
            try
            {
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

                // Add a delay
                System.Threading.Thread.Sleep(6 * 1000);

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

        /// <summary>
        /// To debug this application, call app must be called with args[0] as username and args[1] as password
        /// </summary>
        [Test]
        public void TransactionWorkflow()
        {
            Client.CallCompleted += Client_CallCompleted;
            var tfn = System.IO.Path.GetTempFileName();
            Client.LogToFile(tfn);

            // Execute a transaction
            var transaction = new TransactionBuilder(Client, TestCompany.companyCode, DocumentType.SalesInvoice, "ABC")
                .WithAddress(TransactionAddressType.SingleLocation, "521 S Weller St", null, null, "Seattle", "WA",
                    "98104", "US")
                .WithLine(100.0m, 1, "P0000000")
                .WithLine(200m)
                .WithExemptLine(50m, "NT")
                .WithLineReference("Special Line Reference!", "Also this!")
                .Create();

            // Verify that the call was captured and logged
            Assert.NotNull(lastEvent);
            Assert.True(String.Equals(lastEvent.HttpVerb, "POST", StringComparison.CurrentCultureIgnoreCase));
            Assert.True(String.Equals(lastEvent.RequestUri.ToString(), "https://sandbox-rest.avatax.com/api/v2/transactions/create", StringComparison.CurrentCultureIgnoreCase));
            Assert.AreEqual(lastEvent.Code, HttpStatusCode.Created);

            // Verify that the log file was created
            Assert.True(System.IO.File.Exists(tfn));

            // Ensure this transaction was created, and has three lines, and has some tax
            Assert.NotNull(transaction, "Transaction should have been created");
            Assert.True(transaction.totalTax > 0.0m, "Transaction should have had some tax");
            Assert.True(transaction.lines.Count == 3, "Transaction should have three lines");
            Assert.True(transaction.lines[2].ref1.Contains("Reference!"), "Line3 should have had a Ref1.");

            // Now commit that transaction
            var commitResult = Client.CommitTransaction(TestCompany.companyCode, transaction.code, null, null, new CommitTransactionModel() { commit = true });

            // Ensure that this transaction was committed
            Assert.NotNull(commitResult, "Should have been able to call CommitTransaction");
            Assert.True(commitResult.status == DocumentStatus.Committed, "Transaction should have been committed");

            // Now void the transaction
            var voidResult = Client.VoidTransaction(TestCompany.companyCode, transaction.code, null, null, new VoidTransactionModel()
            {
                code = VoidReasonCode.DocVoided
            });

            // Ensure that the transaction was voided
            Assert.NotNull(voidResult, "Should have been able to call VoidTransactoin");
            Assert.True(voidResult.status == DocumentStatus.Cancelled, "Transaction should have been voided");
        }

        private AvaTaxCallEventArgs lastEvent = null;
        private void Client_CallCompleted(object sender, EventArgs e)
        {
            lastEvent = e as AvaTaxCallEventArgs;
        }
        [Ignore("Ignore Override")]
        [Test]
        public void TaxOverrideExample()
        {
            // Create base transaction.
            var builder = new TransactionBuilder(Client, TestCompany.companyCode, DocumentType.SalesInvoice,
                    "TaxOverrideCustomerCode")
                .WithAddress(TransactionAddressType.SingleLocation, "521 S Weller St", null, null, "Seattle", "WA",
                    "98104", "US")
                .WithLine(100.0m, 1, "P0000000")
                .WithLine(200m);

            var transaction = builder.Create();

            // Ensure this transaction was created.
            Assert.NotNull(transaction, "Transaction should have been created");

            var taxOverrideList = new List<TransactionLineTaxAmountByTaxTypeModel>();
            var item = new TransactionLineTaxAmountByTaxTypeModel();
            item.taxTypeId = "123";
            item.taxAmount = 10;
            taxOverrideList.Add(item);
            // Add Line-level TaxOverride.
            var overrideTransaction = builder
                .WithLineTaxOverride(TaxOverrideType.TaxAmount, "Tax Override Reason", 1)
                .WithLine(300m, 1)
                .WithLineTaxOverride(TaxOverrideType.TaxAmountByTaxType, "Another reason", 10, null, taxOverrideList)
                .Create();


            // Ensure this transaction was created.
            Assert.NotNull(overrideTransaction, "Transaction should have been created");

            // Compare the two transactions.
            Assert.AreEqual(overrideTransaction.totalTaxCalculated, transaction.totalTaxCalculated, "Total Tax Calculated should be the same.");
            Assert.True(overrideTransaction.totalTax < transaction.totalTax, "Total Tax should not be the same. Overridden transaction should be smaller.");

            // Compare the transaction lines.
            var overrideLine = overrideTransaction.lines[1];
            var line = transaction.lines[1];
            Assert.AreEqual(overrideLine.isItemTaxable, line.isItemTaxable);
            Assert.AreEqual(overrideLine.taxCalculated, line.taxCalculated);
            Assert.AreEqual(overrideLine.lineAmount, line.lineAmount);
            Assert.AreEqual(1, overrideLine.tax);
            Assert.True(overrideLine.tax < line.tax);
            Assert.AreEqual(TaxOverrideType.TaxAmount, overrideLine.taxOverrideType);
        }
    }
}
