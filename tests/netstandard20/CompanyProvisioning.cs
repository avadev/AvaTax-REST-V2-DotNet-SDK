using Avalara.AvaTax.RestClient;
using NUnit.Framework;
using System;

namespace Avalara.AvaTax.RestClient.Test.netstandard20
{
    /// <summary>
    /// Helpers for dealing with the delay between creating a test company and
    /// being able to use it.
    /// </summary>
    internal static class CompanyProvisioning
    {
        /// <summary>
        /// The delay this suite has always taken after CompanyInitialize. Kept as
        /// a floor so the wait can only ever get longer, never shorter.
        /// </summary>
        private const int SettleMilliseconds = 6 * 1000;

        /// <summary>
        /// How many times to poll for the company beyond the settle time.
        /// </summary>
        private const int PollAttempts = 12;

        /// <summary>
        /// Milliseconds between polls.
        /// </summary>
        private const int PollIntervalMilliseconds = 2 * 1000;

        /// <summary>
        /// Wait for a newly initialized company to become resolvable by its company
        /// code. CompanyInitialize returns before that is true, and endpoints that
        /// take a companyCode answer 404 until it is, so a fixed delay leaves the
        /// suite failing whenever provisioning runs long.
        ///
        /// This only ever adds waiting. If the company cannot be confirmed the test
        /// still runs and reports its own failure, so a probe that cannot answer
        /// never turns a passing test red.
        /// </summary>
        /// <param name="client">Client that created the company.</param>
        /// <param name="company">Company returned by CompanyInitialize.</param>
        public static void WaitForCompany(AvaTaxClient client, CompanyModel company)
        {
            System.Threading.Thread.Sleep(SettleMilliseconds);

            if (client == null || company == null || String.IsNullOrEmpty(company.companyCode))
            {
                return;
            }

            var filter = "companyCode eq '" + company.companyCode + "'";

            for (var attempt = 0; attempt < PollAttempts; ++attempt)
            {
                try
                {
                    var found = client.QueryCompanies(null, filter, null, null, null);
                    if (found != null && found.value != null && found.value.Count > 0)
                    {
                        return;
                    }
                }
                catch (AvaTaxError e)
                {
                    // The probe itself failed, so it can no longer tell us anything
                    // about the company. Let the test run and report the real error.
                    TestContext.Progress.WriteLine($"Could not query company {company.companyCode}: "
                        + $"HTTP {(int)e.statusCode} ({e.statusCode}); X-Correlation-Id: {e.XCorrelationId}. "
                        + "Continuing without waiting.");
                    return;
                }

                System.Threading.Thread.Sleep(PollIntervalMilliseconds);
            }

            var waited = (SettleMilliseconds + PollAttempts * PollIntervalMilliseconds) / 1000;
            TestContext.Progress.WriteLine($"Company {company.companyCode} (id {company.id}) was still not "
                + $"resolvable by code after {waited}s. Running the test anyway.");
        }
    }
}
