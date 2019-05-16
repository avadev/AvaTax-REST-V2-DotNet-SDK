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
    /// 
    /// Store the ZIP rates locally for those jurisidictions in which you have nexus. 
    /// </summary>
    public static class AvaTaxOfflineHelper
    {
        public static Dictionary<string, TaxRateModel> RatesByZip;


        /// <summary>Caches the content.</summary>
        /// <param name="client"></param>
        /// <param name="region"></param>
        /// <param name="zip"></param>
        /// <param name="path">The fully qualified path where the file will be stored.</param>
        public static void StoreZipRateContent(AvaTaxClient client, string region, string zip, string path)
        {
            //Call rate by ZIP endpoint.
            var rateFile = client.TaxRatesByPostalCode(region, zip);

            //Save the rate by ZIP file in the local ZIP folder.
            WriteZipRateFile(rateFile, zip, path);
        }

        /// <summary>Verifies that the local ZIP-only rate file available.</summary>
        /// <param name="zip">The ZIP code for which you want to verify is available locally.</param>
        /// <param name="path">The path where you stored ZIP-only files.</param>
        /// <returns>bool indicating whether the ZIP rate file is present.</returns>
        public static bool VerifyLocalZipRateAvailable(string zip, string path)
        {
            return File.Exists(string.Format("{0}{1}.json", path, zip));
        }

        /// <summary>Gets the tax rate by zip.</summary>
        /// <param name="zip">The ZIP code for which you want a ZIP-only tax rate.</param>
        /// <param name="path">The path where you stored ZIP-only files.</param>
        /// <returns>The tax rate model object for the requested ZIP, if available</returns>
        public static TaxRateModel GetTaxRateByZip(string zip, string path)
        {
            TaxRateModel zipRate = null;            
            if (RatesByZip == null) {
                RatesByZip = new Dictionary<string, TaxRateModel>();
            }

            //First see if the ZIP rate file is available in the dictionary.
            if (RatesByZip.ContainsKey(zip)) {
                zipRate = RatesByZip[zip];
            } else if (VerifyLocalZipRateAvailable(zip, path)) {
                RatesByZip.Add(zip, ReadZipRateFile(zip, path));
                zipRate = RatesByZip[zip];
            }

            return zipRate;         
        }

        /// <summary>Writes the zip rate file.</summary>
        /// <param name="zipRate">The zip rate.</param>
        /// <param name="zip">The zip.</param>
        /// <param name="path">The path.</param>
        private static void WriteZipRateFile(TaxRateModel zipRate, string zip, string path)
        {
            TextWriter writer = null;

            try {
                var content = JsonConvert.SerializeObject(zipRate);
                writer = new StreamWriter(string.Format("{0}{1}.json", path, zip));
                writer.Write(content);
            }
            finally {
                if (writer != null) {
                    writer.Flush();
                    writer.Close();      
                }
            }
        }

        private static TaxRateModel ReadZipRateFile(string zip, string path)
        {
            TextReader reader = null;

            try {
                reader = new StreamReader(string.Format("{0}{1}.json", path, zip));
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
