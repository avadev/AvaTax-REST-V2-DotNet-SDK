using Avalara.AvaTax.RestClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Avalara.AvaTax.RestClient.Test.net80
{
    [TestFixture]
    public class BatchTests
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
                    companyCode = Guid.NewGuid().ToString("N").Substring(0, 25),
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
                Assert.NotNull(TestCompany, "Test company should be created");
                Assert.True(TestCompany.nexus.Count > 0, "Test company should have nexus");
                Assert.True(TestCompany.locations.Count > 0, "Test company should have locations");

                // Shouldn't fail
            } catch (Exception ex)
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
            } catch (Exception ex)
            {
                Assert.Fail("Exception in TearDown: " + ex);
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public async Task BatchesWorkflow()
        {
            // Raw batch CSV string.
            const string transactionImport = @"ProcessCode,DocCode,DocType,DocDate,CompanyCode,CustomerCode,EntityUseCode,LineNo,TaxCode,TaxDate,ItemCode,Description,Qty,Amount,Discount,Ref1,Ref2,ExemptionNo,RevAcct,DestAddress,DestCity,DestRegion,DestPostalCode,DestCountry,OrigAddress,OrigCity,OrigRegion,OrigPostalCode,OrigCountry,LocationCode,SalesPersonCode,PurchaseOrderNo,CurrencyCode,ExchangeRate,ExchangeRateEffDate,PaymentDate,TaxIncluded,DestTaxRegion,OrigTaxRegion,Taxable,TaxType,TotalTax,CountryName,CountryCode,CountryRate,CountryTax,StateName,StateCode,StateRate,StateTax,CountyName,CountyCode,CountyRate,CountyTax,CityName,CityCode,CityRate,CityTax,Other1Name,Other1Code,Other1Rate,Other1Tax,Other2Name,Other2Code,Other2Rate,Other2Tax,Other3Name,Other3Code,Other3Rate,Other3Tax,Other4Name,Other4Code,Other4Rate,Other4Tax,ReferenceCode,BuyersVATNo
3,BS1323154187029MG10,2,16-Apr-14,,029MG10,,0000000001,SR060100,06-May-14,6500,REPAIRS & MAINTENANCE,,1980,,,0,,6500,119 N. 72nd St.,Omaha,NE,68114,,6923 MAPLE ST,OMAHA,NE,68104,,029,,,USD,,,,0,,,,,0,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
3,BS1323158772194036MAC1,2,04-Apr-14,,036MAC1,,0000000001,SC150158,06-May-14,6505,R&M HEAT / VENT / AIR COND,,322.26,,,0,,6505,1200 E. Mall Drive,Holland,OH,43528,,2875 CRANE WAY,NORTHWOOD,OH,43619,,036,,,USD,,,,0,,,,,0,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
3,BS1323159W206409036MLK,2,25-Mar-14,,036MLK,,0000000001,SR060100,06-May-14,6507,R&M OTHER,,449,,,31.43,,6507,1200 E. Mall Drive,Holland,OH,43528,,1214 JEFFERSON AVE,TOLEDO,OH,43604,,036,,,USD,,,,0,,,,,0,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
3,BS13231601596048MRP2,2,02-May-14,,048MRP2,,0000000001,SR060100,06-May-14,6520,FURNITURE REPAIRS,,60,,,0,,6520,2201 Hwy 75 North,Sherman,TX,75090,,P.O. BOX 125,POTTSBORO,TX,75076,,048,,,USD,,,,0,,,,,0,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
3,BS13231631591048MRP2,2,02-May-14,,048MRP2,,0000000001,SR060100,06-May-14,6520,FURNITURE REPAIRS,,58,,,0,,6520,2201 Hwy 75 North,Sherman,TX,75090,,P.O. BOX 125,POTTSBORO,TX,75076,,048,,,USD,,,,0,,,,,0,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
3,BS13231611594048MRP2,2,01-May-14,,048MRP2,,0000000001,SR060100,06-May-14,6520,FURNITURE REPAIRS,,65,,,0,,6520,2201 Hwy 75 North,Sherman,TX,75090,,P.O. BOX 125,POTTSBORO,TX,75076,,048,,,USD,,,,0,,,,,0,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
3,BS13231621593048MRP2,2,01-May-14,,048MRP2,,0000000001,SR060100,06-May-14,6520,FURNITURE REPAIRS,,75,,,0,,6520,2201 Hwy 75 North,Sherman,TX,75090,,P.O. BOX 125,POTTSBORO,TX,75076,,048,,,USD,,,,0,,,,,0,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
3,BS13231641587048MRP2,2,01-May-14,,048MRP2,,0000000001,SR060100,06-May-14,6520,FURNITURE REPAIRS,,60,,,0,,6520,2201 Hwy 75 North,Sherman,TX,75090,,P.O. BOX 125,POTTSBORO,TX,75076,,048,,,USD,,,,0,,,,,0,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
3,BS13231651582048MRP2,2,15-Mar-14,,048MRP2,,0000000001,SR060100,06-May-14,6520,FURNITURE REPAIRS,,47,,,0,,6520,2201 Hwy 75 North,Sherman,TX,75090,,P.O. BOX 125,POTTSBORO,TX,75076,,048,,,USD,,,,0,,,,,0,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,";

            // Let's Create the file portion of the batch request.
            var batchFileModel = new BatchFileModel
            {
                name = "TransactionImport.csv",
                content = Encoding.UTF8.GetBytes(transactionImport),
                contentType = "text/csv",
                fileExtension = "csv"
            };

            // Create the bare-minimum batch header info.
            var batchRequest = new BatchModel
            {
                name = "AutomationTestBatch",
                type = BatchType.TransactionImport,
                files = new List<BatchFileModel> { batchFileModel }
            };

            // Send the batch!
            try
            {
                var batchResult = Client.CreateBatches(TestCompany.id, new List<BatchModel> { batchRequest });
                Assert.NotNull(batchResult, "Batch not sent.");
                Assert.True(batchResult.Count > 0, "No batches created.");

                // Check that the batch comes out of Waiting state using a linear backoff strategy.
                var waiting = true;
                BatchModel batchFetchResult = null;
                for (var i = 1; i < 6; ++i)
                {
                    await Task.Delay(i * 1000);

                    batchFetchResult = Client.GetBatch(TestCompany.id, batchResult[0].id.Value);
                    Assert.NotNull(batchFetchResult, "Batch fetch unsuccessful.");
                    if (batchFetchResult.status.Value == BatchStatus.Waiting) continue;
                    waiting = false;
                    break;
                }
                Assert.True(waiting == false, $"Batch waiting too long. Check BatchId: {batchResult[0].id}");

                // This batch is no longer in the Waiting state. Let's see it process.
                var processing = true;
                for (var i = 1; i < 11; ++i)
                {
                    await Task.Delay(i * 1000);

                    batchFetchResult = Client.GetBatch(TestCompany.id, batchResult[0].id.Value);
                    Assert.NotNull(batchFetchResult, "Batch fetch unsuccessful.");
                    if (batchFetchResult.status.Value == BatchStatus.Processing) continue;
                    processing = false;
                    break;
                }
                Assert.True(processing == false, $"Batch processing too long. Check BatchId: {batchResult[0].id}");

                // This batch is done processing. 
                Assert.True((batchFetchResult.status.Value == BatchStatus.Errors || batchFetchResult.status.Value == BatchStatus.Completed),
                    $"BatchId: {batchResult[0].id} should either complete or error out.");
                // Ensure that the number of records matches what we sent in.
                Assert.AreEqual(9, batchFetchResult.currentRecord.Value);

                // Alright. Time to download the sent batch file.
                var fileResult = Client.DownloadBatch(TestCompany.id, batchFetchResult.id.Value, batchFetchResult.files[0].id.Value);
                Assert.NotNull(fileResult);

                // Compare what we got back with what we sent.
                Assert.AreEqual(batchFetchResult.name + ".Input.CSV; filename*=UTF-8''" + batchFetchResult.name + ".Input.CSV", fileResult.Filename);
                Assert.AreEqual(batchFileModel.content, fileResult.Data);
                Assert.AreEqual(batchFileModel.contentType, fileResult.ContentType);
            } catch (AvaTaxError e)
            {
                Assert.True(false, $"AvaTaxError: {e.error.error.details?[0].message}");
            } catch (Exception e)
            {
                Assert.True(false, $"Unknown Exception! {e.Message}");
            }
        }
    }
}
