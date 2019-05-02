using Avalara.AvaTax.RestClient;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.IO;
using System.Net;
using System.Reflection;

namespace Tests.Avalara.AvaTax.RestClient.netstandard
{
    [TestFixture]
    public class CertificateTests
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
            try {
                // Create a client and set up authentication
                Client = new AvaTaxClient(typeof(CertificateTests).Name,
                    typeof(CertificateTests).GetTypeInfo().Assembly.ImageRuntimeVersion.ToString(),
                    Environment.MachineName,
                    AvaTaxEnvironment.Sandbox)
                    .WithSecurity(Environment.GetEnvironmentVariable("SANDBOX_USERNAME"), Environment.GetEnvironmentVariable("SANDBOX_PASSWORD"));

                // Verify that we can ping successfully
                var pingResult = Client.Ping();

                // Assert that ping succeeded
                Assert.NotNull(pingResult, "Should be able to call Ping");
                Assert.True(pingResult.authenticated, "Environment variables should provide correct authentication");

                //Get the default company.
                var defaultCompanyModel = Client.QueryCompanies(string.Empty, "isDefault EQ true", null, null, string.Empty).value[0];

                DefaultCompanyId = defaultCompanyModel.id;

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
            } catch (Exception ex) {
                Assert.Fail("Exception in SetUp: " + ex);
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
                Assert.Fail("Exception in TearDown: " + ex);
            }
        }
        #endregion

        /// <summary>
        /// Tests the upload certificate image endpoint.
        /// </summary>
        [Test]
        public void CertificateImageUploadTest()
        {
            //Get the cert number. The account needs to have CertCapture 
            //be provisioned, already have a certificate created, and the
            //certificate needs to be valid.
            var certs = Client.QueryCertificates(DefaultCompanyId, string.Empty, "valid EQ true", null, null, string.Empty).value;
            var certId = certs[0].id.Value;

            //Get an image.
            byte[] jpegByteArr = File.ReadAllBytes(Environment.GetEnvironmentVariable("TEST_IMAGE_PATH"));

            FileResult fileResult = new FileResult()
            {
                ContentType = "multipart/form-data",
                Filename = "test_cert_image.jpg",
                Data = jpegByteArr
            };

            //Send request.
            var certUploadResult = Client.UploadCertificateImage(DefaultCompanyId, certId, fileResult);

            //Response should be "OK"
            Assert.True(string.Equals(certUploadResult, "\"OK\""));

            //Test download of image attachment.
            var certAttachment = Client.DownloadCertificateImage(DefaultCompanyId, certId, null, CertificatePreviewType.Pdf);
            Assert.NotNull(certAttachment);
            Assert.True(string.Equals(certAttachment.ContentType, "application/pdf"));
            Assert.True(certAttachment.Data.Length > 1000);
            
        }
    }
}
