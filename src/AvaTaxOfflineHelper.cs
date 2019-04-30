using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalara.AvaTax.RestClient.net45
{
    /// <summary>
    /// This class contains methods to assist with content for offline calculations. 
    /// </summary>
    public class AvaTaxOfflineHelper
    {
        /// <summary>Caches the content.</summary>
        public static void CacheRateContent(AvaTaxClient client, string region, string zip)
        {
            //Call rate by ZIP endpoint.
            var rateFile = client.TaxRatesByPostalCode(region, zip);

            //Save the rate by ZIP file in the local ZIP folder.
            string rateFileString = rateFile.ToString();
        }

        /// <summary>Verifies the local zip rate available.</summary>
        /// <param name="zip">The zip.</param>
        /// <returns></returns>
        public static bool VerifyLocalZipRateAvailable(string zip)
        {
            return false;
        }
    }
}
