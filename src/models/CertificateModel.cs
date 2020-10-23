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
    /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
    /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
    /// criteria you specify when you store the certificate. To view or manage your certificates directly, please
    /// log onto the administrative website for the product you purchased.
    /// </summary>
    public class CertificateModel
    {
        /// <summary>
        /// Unique ID number of this certificate.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The unique ID number of the AvaTax company that recorded this certificate.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// The date when this certificate was signed.
        /// </summary>
        public DateTime signedDate { get; set; }

        /// <summary>
        /// Expiration date when this certificate will no longer be valid.
        /// </summary>
        public DateTime expirationDate { get; set; }

        /// <summary>
        /// File name for the image of this certificate.
        ///  
        /// When creating a certificate, if you do not upload a PDF or JPG image, you must specify the filename
        /// of the certificate as it is tracked in your repository.
        ///  
        /// To create a certificate, you must provide one of the following fields: either a `filename`, a `pdf` file,
        /// or an array of JPG `pages`. The API will return an error if you omit these fields or if you attempt to
        /// put values in more than one of them.
        /// </summary>
        public String filename { get; set; }

        /// <summary>
        /// This value is true if there exists scanned PDF copy of this certificate or the PDF version of the form that the customer filled via the CertCapture wizard on S3 bucket.
        /// </summary>
        public Boolean? documentExists { get; set; }

        /// <summary>
        /// True if this certificate is marked as valid. A valid certificate can be considered for exemption purposes.
        /// When a certificate is marked invalid, it will no longer be considered when calculating exemption for
        /// a customer.
        /// </summary>
        public Boolean? valid { get; set; }

        /// <summary>
        /// This value is true if the certificate has gone through the certificate validation process.
        /// For more information on the certificate validation process, please see the Avalara Help Center.
        /// </summary>
        public Boolean? verified { get; set; }

        /// <summary>
        /// If this certificate provides exemption from transactional taxes, what percentage of the transaction
        /// is considered exempt?
        ///  
        /// For a fully exempt certificate, this percentage should be 100.
        /// </summary>
        public Decimal? exemptPercentage { get; set; }

        /// <summary>
        /// This value is true if this certificate is a single (or standalone) certificate. This value is set
        /// during the audit stage of the certificate validation process.
        /// </summary>
        public Boolean? isSingleCertificate { get; set; }

        /// <summary>
        /// Indicates the tax number passed in for the certificate.
        /// </summary>
        public String exemptionNumber { get; set; }

        /// <summary>
        /// The exemption reason that CertCapture audit/internal logic identifies for created certificate.
        /// </summary>
        public  validatedExemptionReason { get; set; }

        /// <summary>
        /// The exemption reason associated with this certificate. For example, the reason code for exemption
        /// for purposes of resale is `RESALE`.
        ///  
        /// For a list of exemption reasons, call `ListCertificateExemptReasons`.
        /// </summary>
        public  exemptionReason { get; set; }

        /// <summary>
        /// The status of the certificate
        /// </summary>
        public String status { get; set; }

        /// <summary>
        /// The date/time when this record was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// The tax number type for the certificate. For example, `FEIN`, `Social Security Number`, or `Employer Identification Number`.
        /// </summary>
        public String taxNumberType { get; set; }

        /// <summary>
        /// Description of business for the certificate. For example, `Retail trade`, `Professional services`, or `Construction`.
        /// </summary>
        public String businessNumberType { get; set; }

        /// <summary>
        /// Number of pages contained within this certificate.
        /// </summary>
        public Int32? pageCount { get; set; }

        /// <summary>
        /// A list of customers to which this certificate applies. You can fetch this data by specifying
        /// `$include=customers` when calling a certificate fetch API.
        /// </summary>
        public List<> customers { get; set; }

        /// <summary>
        /// A list of purchase order numbers that are valid for use with this certificate.
        ///  
        /// If this certificate is applicable for all purchase order numbers, this field will be empty.
        ///  
        /// You can fetch this data by specifying `$include=po_numbers` when calling a certificate fetch API.
        /// </summary>
        public List<> poNumbers { get; set; }

        /// <summary>
        /// The exposure zone where this certificate is valid.
        /// </summary>
        public  exposureZone { get; set; }

        /// <summary>
        /// A list of certificate attributes that apply to this certificate.
        ///  
        /// You can fetch this data by specifying `$include=attributes` when calling a certificate fetch API.
        /// </summary>
        public List<> attributes { get; set; }

        /// <summary>
        /// The unique ID number of current AvaTax Exemption Certificate that refers this certificate.
        /// </summary>
        public Int32? ecmsId { get; set; }

        /// <summary>
        /// The status of current AvaTax Exemption Certificate that refers to this certificate.
        /// </summary>
        public String ecmsStatus { get; set; }

        /// <summary>
        /// This field is available for input only. To retrieve the image after creation, use the
        /// `DownloadCertificateImage` API.
        ///  
        /// When creating a certificate, you may optionally provide a PDF image in Base64 URLEncoded format.
        /// PDFs are automatically parsed into individual page JPG images and can be retrieved back
        /// later as either the original PDF or the individual pages.
        ///  
        /// To create a certificate, you must provide one of the following fields: either a `filename`, a `pdf` file,
        /// or an array of JPG `pages`. The API will return an error if you omit these fields or if you attempt to
        /// put values in more than one of them.
        /// </summary>
        public String pdf { get; set; }

        /// <summary>
        /// This field is available for input only. To retrieve the image after creation, use the
        /// `DownloadCertificateImage` API.
        ///  
        /// When creating a certificate, you may optionally provide a list of JPG images, one per page, in
        /// Base64 URLEncoded format. These JPG images are automatically combined into a single downloadable
        /// PDF and can be retrieved back later as either the original JPG images or the combined PDF.
        ///  
        /// To create a certificate, you must provide one of the following fields: either a `filename`, a `pdf` file,
        /// or an array of JPG `pages`. The API will return an error if you omit these fields or if you attempt to
        /// put values in more than one of them.
        /// </summary>
        public List<String> pages { get; set; }


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
