using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Exempt certificate
    /// </summary>
    public class EcmsModel
    {
        /// <summary>
        /// Exempt certificate ID
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
        /// Region
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// Postal code / zip code
        /// </summary>
        public String postalCode { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// Exempt cert type
        /// </summary>
        public ExemptCertTypeId exemptCertTypeId { get; set; }

        /// <summary>
        /// Document Reference Number
        /// </summary>
        public String documentRefNo { get; set; }

        /// <summary>
        /// Business type
        /// </summary>
        public Byte businessTypeId { get; set; }

        /// <summary>
        /// Other description for this business type
        /// </summary>
        public String businessTypeOtherDescription { get; set; }

        /// <summary>
        /// Exempt reason ID
        /// </summary>
        public String exemptReasonId { get; set; }

        /// <summary>
        /// Other description for exempt reason
        /// </summary>
        public String exemptReasonOtherDescription { get; set; }

        /// <summary>
        /// Effective date for this exempt certificate
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// Applicable regions for this exempt certificate
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
        /// Which country issued this exempt certificate
        /// </summary>
        public String countryIssued { get; set; }

        /// <summary>
        /// Certificate ID for AvaTax?
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
