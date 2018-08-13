using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Exempt certificate
    /// </summary>
    public class EcmsModel
    {
        /// <summary>
        /// The calc_id associated with a certificate in CertCapture.
        /// </summary>
        public Int32 exemptCertId { get; set; }

        /// <summary>
        /// Company ID
        /// </summary>
        public Int32 companyId { get; set; }

        /// <summary>
        /// Customer code
        /// </summary>
        public String customerCode { get; set; }

        /// <summary>
        /// Customer name
        /// </summary>
        public String customerName { get; set; }

        /// <summary>
        /// Address line 1
        /// </summary>
        public String address1 { get; set; }

        /// <summary>
        /// Address line 2
        /// </summary>
        public String address2 { get; set; }

        /// <summary>
        /// Address line 3
        /// </summary>
        public String address3 { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public String city { get; set; }

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
        /// Postal code / zip code
        /// </summary>
        public String postalCode { get; set; }

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
        /// The type of exemption certificate. Permitted values are: Blanket and Single.
        /// </summary>
        public ExemptCertTypeId exemptCertTypeId { get; set; }

        /// <summary>
        /// Document Reference Number, in the case of single-use exemption certificates, the DocumentCode or PurchaseOrderNo to which the certificate should apply.
        /// </summary>
        public String documentRefNo { get; set; }

        /// <summary>
        /// Business type the customer belongs to.
        /// </summary>
        public Byte businessTypeId { get; set; }

        /// <summary>
        /// Other description for this business type
        /// </summary>
        public String businessTypeOtherDescription { get; set; }

        /// <summary>
        /// Exempt reason associated with the certificate, coded by CustomerUsageType.
        /// Example: A - Federal Government.
        /// </summary>
        public String exemptReasonId { get; set; }

        /// <summary>
        /// Other description for exempt reason i.e. Populated on if exemptReasonId is 'L' - Other.
        /// </summary>
        public String exemptReasonOtherDescription { get; set; }

        /// <summary>
        /// Effective date for this exempt certificate
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// A list of applicable regions for this exempt certificate.
        /// 
        /// To list more than one applicable region, separate the list of region codes with commas.
        /// </summary>
        public String regionsApplicable { get; set; }

        /// <summary>
        /// Status for this exempt certificate
        /// </summary>
        public ExemptCertStatusId exemptCertStatusId { get; set; }

        /// <summary>
        /// Date when this exempt certificate was created
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// Date when last transaction with this exempt certificate happened
        /// </summary>
        public DateTime? lastTransactionDate { get; set; }

        /// <summary>
        /// When this exempt certificate will expire
        /// </summary>
        public DateTime? expiryDate { get; set; }

        /// <summary>
        /// User that creates the certificate
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// Date when this exempt certificate was modified
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// Who modified this exempt certificate
        /// </summary>
        public Int32? modifiedUserId { get; set; }

        /// <summary>
        /// Name or ISO 3166 code identifying the country that issued this ECMS certificate.
        /// 
        /// This field supports many different country identifiers:
        ///  * Two character ISO 3166 codes
        ///  * Three character ISO 3166 codes
        ///  * Fully spelled out names of the country in ISO supported languages
        ///  * Common alternative spellings for many countries
        /// 
        /// For a full list of all supported codes and names, please see the Definitions API `ListCountries`.
        /// </summary>
        public String countryIssued { get; set; }

        /// <summary>
        /// If the certificate record was synced from an AvaTax Certs account(as opposed to being entered in ECMS directly), 
        /// the unique AvaTax Certs identifier for the certificate record. Usually same as the Id of a Certificate.
        /// </summary>
        public String avaCertId { get; set; }

        /// <summary>
        /// Review status for this exempt certificate
        /// </summary>
        public ExemptCertReviewStatusId? exemptCertReviewStatusId { get; set; }

        /// <summary>
        /// Exempt Cert details
        /// </summary>
        public List<EcmsDetailModel> details { get; set; }


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
