using Newtonsoft.Json;
using System;
using System.Collections.Generic;
#if !NET20
using System.Collections.Concurrent;
#endif
using System.IO;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// This class provides a wrapper for exceptions that may occur during use of the 
    /// AvaTaxOffLineHelper class.
    /// </summary>
    public class AvaTaxOfflineHelperException : Exception
    {
        /// <summary>Initializes a new instance of the <see cref="AvaTaxOfflineHelperException"/> class.</summary>
        /// <param name="exc">The exception to wrap.</param>
        public AvaTaxOfflineHelperException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    /// <summary>This class contains methods to assist with content for offline calculations.
    /// Store the rate or content files locally for those jurisidictions in which you have nexus.</summary>
    public static class AvaTaxOfflineHelper
    {
        /// <summary>
        /// A Dictionary of AvaTax tax rate model objects. The dictionary key 
        /// is the ZIP code for which you wish to retrieve a TaxRateModel, if
        /// it has been downloaded.
        /// </summary>
#if NET20
        private static readonly Dictionary<string, TaxRateModel> _ratesByZip = new Dictionary<string, TaxRateModel>();
#else
        private static readonly ConcurrentDictionary<string, TaxRateModel> _ratesByZip = new ConcurrentDictionary<string, TaxRateModel>();
#endif


        /// <summary>
        /// Initializes a new instance of the <see cref="AvaTaxOfflineHelper"/> class.
        /// </summary>
        //public AvaTaxOfflineHelper()
        //{
        //    _ratesByZip = new Dictionary<string, TaxRateModel>();
        //}

        /// <summary>
        /// Downloads and stores a ZIP code TaxRateModel object and stores it in the location
        /// designated. Call this method with the Z
        /// </summary>
        /// <param name="client"></param>
        /// <param name="region"></param>
        /// <param name="zip"></param>
        /// <param name="path">The fully qualified path where the file will be stored.</param>
        public static void StoreZipRateContent(AvaTaxClient client, string region, List<string> zips, string path)
        {
            try {
                foreach (string zip in zips) {
                    //Call rate by ZIP endpoint.
                    var rateFile = client.TaxRatesByPostalCode(region, zip);

                    //Save the rate by ZIP file in the local ZIP folder.
                    WriteZipRateFile(rateFile, zip, path);
                }
            }
            catch (Exception exc) {
                throw new AvaTaxOfflineHelperException("An error occurred retrieving or storing the rate content. Please see inner exception for details.", exc);
            }
        }

        /// <summary>Verifies that the local ZIP-only rate file available.</summary>
        /// <param name="zip">The ZIP code for which you want to verify is available locally.</param>
        /// <param name="path">The path where you stored ZIP-only files.</param>
        /// <returns>bool indicating whether the ZIP rate file is present.</returns>
        public static bool VerifyLocalZipRateAvailable(string zip, string path)
        {
            try {
                return File.Exists(Path.Combine(path, zip + ".json"));
            }
            catch (Exception exc) {
                throw new AvaTaxOfflineHelperException("An error occurred verifying the local rate content. Please see inner exception for details.", exc);
            }
        }

        /// <summary>
        /// Gets the tax rate information for ZIP centroid and stores it locally.
        /// </summary>
        /// <param name="zip">The ZIP code for which you want a ZIP-only tax rate.</param>
        /// <param name="path">The path where you stored ZIP-only files.</param>
        /// <returns>The tax rate model object for the requested ZIP, if available</returns>
        public static TaxRateModel GetLocalTaxRateByZip(string zip, string path)
        {
            try {
                TaxRateModel zipRate = null;                

                //First see if the ZIP rate file is available in the dictionary.
                if (_ratesByZip.ContainsKey(zip)) {
                    zipRate = _ratesByZip[zip];
                } else if (VerifyLocalZipRateAvailable(zip, path)) {
#if NET20
                    _ratesByZip.Add(zip, ReadZipRateFile(zip, path));
#else
                    _ratesByZip.TryAdd(zip, ReadZipRateFile(zip, path));
#endif
                    zipRate = _ratesByZip[zip];
                }

                return zipRate;
            }
            catch(Exception exc) {
                throw new AvaTaxOfflineHelperException("An error occurred retrieving local rate content. Please see inner exception for details.", exc);
            }
        }

#if PORTABLE
        /// <summary>Writes the ZIP rate file to the designated location.</summary>
        /// <param name="zipRate">The ZIP rate object to store locally.</param>
        /// <param name="zip">The ZIP code of the rate object.</param>
        /// <param name="path">The path in which to store the file.</param>
        private static void WriteZipRateFile(TaxRateModel zipRate, string zip, string path)
        {
            var content = JsonConvert.SerializeObject(zipRate);
            File.WriteAllText(Path.Combine(path, zip + ".json"), content);
        }

        /// <summary>Reads the ZIP rate file from the designated location.</summary>        
        /// <param name="zip">The ZIP code you wish to retrieve from local storage.</param>
        /// <param name="path">The path where you stored the ZIP code rate files.</param>
        private static TaxRateModel ReadZipRateFile(string zip, string path)
        {
            var content = File.ReadAllText(Path.Combine(path, zip + ".json"));
            return JsonConvert.DeserializeObject<TaxRateModel>(content);
        }
    }
}
#else

        /// <summary>Writes the ZIP rate file to the designated location.</summary>
        /// <param name="zipRate">The ZIP rate object to store locally.</param>
        /// <param name="zip">The ZIP code of the rate object.</param>
        /// <param name="path">The path in which to store the file.</param>
        private static void WriteZipRateFile(TaxRateModel zipRate, string zip, string path)
        {
            TextWriter writer = null;

            try {
                Directory.GetAccessControl(path);
                var content = JsonConvert.SerializeObject(zipRate);
                writer = new StreamWriter(Path.Combine(path, zip + ".json"));
                writer.Write(content);
            }            
            finally {
                if (writer != null) {
                    writer.Flush();
                    writer.Close();      
                }
            }
        }

        /// <summary>
        /// Reads the zip rate file.
        /// </summary>
        /// <param name="zip">The zip.</param>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        private static TaxRateModel ReadZipRateFile(string zip, string path)
        {
            TextReader reader = null;

            try {
                reader = new StreamReader(Path.Combine(path, zip + ".json"));
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
#endif