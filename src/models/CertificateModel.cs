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
    /// Certificate model in CertCapture
    /// </summary>
    public class CertificateModel
    {
        /// <summary>
        /// Cerificate ID
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The unique ID number of the AvaTax company that received this certificate.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// When the certifcate was signed
        /// </summary>
        public DateTime? signedDate { get; set; }

        /// <summary>
        /// When the certificate will be/was expired
        /// </summary>
        public DateTime? expirationDate { get; set; }

        /// <summary>
        /// File name for the certificate
        /// </summary>
        public String filename { get; set; }

        /// <summary>
        /// Is the certificate valid?
        /// </summary>
        public Boolean? valid { get; set; }

        /// <summary>
        /// Is the certificate verified?
        /// </summary>
        public Boolean? verified { get; set; }

        /// <summary>
        /// The certificate is never renewed
        /// </summary>
        public Boolean? neverRenew { get; set; }

        /// <summary>
        /// Is this certificate renewable?
        /// </summary>
        public Boolean? renewable { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Boolean? unusedMultiCert { get; set; }

        /// <summary>
        /// What is the exempt percentage from this certificate
        /// </summary>
        public Decimal? exemptPercentage { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Int32? verificationNumber { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Int32? taxNumber { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Boolean? barcodeRead { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Boolean? isSingle { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Int32? legacyCertificateId { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Int32? calcId { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public CertificateTaxCodeModel expectedTaxCode { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public CertificateTaxCodeModel actualTaxCode { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public ExposureZoneModel exposureZone { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Int32? replacement { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public String certificateNumber { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Boolean? jsSingle { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public String taxNumberType { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Int32? businessNumber { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public String businessNumberType { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public String exemptReasonDescription { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public String sstMetadata { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Int32? pageCount { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Int32? communicationId { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Int32? locationId { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Int32? documentTypeId { get; set; }

        /// <summary>
        /// A list of customers to which this certificate applies.
        /// </summary>
        public List<CustomerModel> customers { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public List<PoNumberModel> poNumber { get; set; }


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
