using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            WriteZipRateFile(rateFile, zip);
        }

        /// <summary>Verifies the local zip rate available.</summary>
        /// <param name="zip">The ZIP code rate file to verify is available locally.</param>
        /// <returns>bool indicating whether the ZIP rate file is present.</returns>
        public static bool VerifyLocalZipRateAvailable(string zip)
        {
            return File.Exists(string.Format(@"C:\git\develop\AvaTax-REST-V2-DotNet-SDK\src\taxRatesByZip\{0}.json", zip));
        }

        private static void WriteZipRateFile(TaxRateModel zipRate, string zip)
        {
            TextWriter writer = null;

            try {
                var content = JsonConvert.SerializeObject(zipRate);
                writer = new StreamWriter(string.Format(@"C:\git\develop\AvaTax-REST-V2-DotNet-SDK\src\taxRatesByZip\{0}", string.Format("{0}.json", zip)));
                writer.Write(content);
            }
            finally {
                if (writer != null) {
                    writer.Flush();
                    writer.Close();      
                }
            }
        }

        private static TaxRateModel ReadZipRateFile(string zip)
        {
            TextReader reader = null;

            try {
                reader = new StreamReader(string.Format(@"C:\git\develop\AvaTax-REST-V2-DotNet-SDK\src\taxRatesByZip\{0}.json", zip));
                var contents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<TaxRateModel>(contents);
            }
            finally {
                if (reader != null) {
                    reader.Close();
                }
            }
        }
    }
}
