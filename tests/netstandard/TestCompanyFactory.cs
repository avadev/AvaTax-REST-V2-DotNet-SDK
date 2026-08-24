using Avalara.AvaTax.RestClient;
using NUnit.Framework;
using System;

namespace Avalara.AvaTax.RestClient.Test.netstandard
{
    /// <summary>
    /// Supplies the company the tests run against.
    ///
    /// By default every fixture initializes a throwaway company, which leaves a
    /// new company in the account per test and depends on a freshly created
    /// company being immediately usable. Set SANDBOX_COMPANY_CODE to reuse one
    /// existing company instead; the fixtures then skip both creation and the
    /// teardown that deactivates it.
    /// </summary>
    internal static class TestCompanyFactory
    {
        /// <summary>
        /// Environment variable naming the company to reuse.
        /// </summary>
        private const string CompanyCodeVariable = "SANDBOX_COMPANY_CODE";

        /// <summary>
        /// True when the suite is reusing an existing company, which must never
        /// be deactivated by teardown.
        /// </summary>
        public static bool IsReusing
        {
            get { return !String.IsNullOrEmpty(CompanyCode); }
        }

        private static string CompanyCode
        {
            get { return Environment.GetEnvironmentVariable(CompanyCodeVariable); }
        }

        /// <summary>
        /// Fetch the company named by SANDBOX_COMPANY_CODE, including its nexus and
        /// locations so the fixtures' own assertions still hold. Returns null when
        /// the variable is unset, so the caller creates a company as before.
        /// </summary>
        /// <param name="client">Client to look the company up with.</param>
        public static CompanyModel Existing(AvaTaxClient client)
        {
            var code = CompanyCode;
            if (client == null || String.IsNullOrEmpty(code))
            {
                return null;
            }

            var found = client.QueryCompanies("Nexus,Locations", "companyCode eq '" + code + "'", 1, null, null);
            Assert.True(found != null && found.value != null && found.value.Count > 0,
                $"{CompanyCodeVariable} is set to '{code}' but no company with that code was found.");

            var company = found.value[0];
            TestContext.Progress.WriteLine($"Reusing company '{code}' (id {company.id}) "
                + $"with {(company.nexus == null ? 0 : company.nexus.Count)} nexus and "
                + $"{(company.locations == null ? 0 : company.locations.Count)} locations.");
            return company;
        }
    }
}
