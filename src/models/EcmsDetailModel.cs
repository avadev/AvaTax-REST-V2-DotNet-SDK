using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2019 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Genevieve Conty
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents an ECMS record, used internally by AvaTax to track information about exemptions.
    /// </summary>
    public class EcmsDetailModel
    {
        /// <summary>
        /// Unique, system-assigned identifier of a ExemptCertDetail record.
        /// </summary>
        public Int32 exemptCertDetailId { get; set; }

        /// <summary>
        /// The calc_id associated with a certificate in CertCapture.
        /// </summary>
        public Int32 exemptCertId { get; set; }

        /// <summary>
        /// State FIPS
        /// </summary>
        public String stateFips { get; set; }

        /// <summary>
        /// Name or ISO 3166 code identifying the region within the country.
        ///  
        /// This field supports many different region identifiers:
        ///  * Two and three character ISO 3166 region codes
        ///  * Fully spelled out names of the region in ISO supported languages
        ///  * Common alternative spellings for many regions
        ///  
        /// For a full list of all supported codes and names, please see the Definitions API `ListRegions`.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// The customer Tax Id Number (tax_number) associated with a certificate. This is same as exemptionNo in Transactions.
        /// </summary>
        public String idNo { get; set; }

        /// <summary>
        /// Name or ISO 3166 code identifying the country.
        ///  
        /// This field supports many different country identifiers:
        ///  * Two character ISO 3166 codes
        ///  * Three character ISO 3166 codes
        ///  * Fully spelled out names of the country in ISO supported languages
        ///  * Common alternative spellings for many countries
        ///  
        /// For a full list of all supported codes and names, please see the Definitions API `ListCountries`.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// End date of this exempt certificate
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The type of idNo (tax_number) associated with a certificate.
        /// Example: Driver's Licence Number, Permit Number.
        /// </summary>
        public String idType { get; set; }

        /// <summary>
        /// Is the tax code list an exculsion list?
        /// </summary>
        public Int32? isTaxCodeListExclusionList { get; set; }

        /// <summary>
        /// optional: list of tax code associated with this exempt certificate detail
        /// </summary>
        public List<EcmsDetailTaxCodeModel> taxCodes { get; set; }


        /// <summary>
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
