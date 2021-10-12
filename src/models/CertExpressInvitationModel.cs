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
    /// Represents an invitation for a customer to use CertExpress to self-report their own certificates.
    /// This invitation is delivered by your choice of method, or you can present a hyperlink to the user
    /// directly in your connector. Your customer will be redirected to https://app.certexpress.com/ where
    /// they can follow a step-by-step guide to enter information about their exemption certificates. The
    /// certificates entered will be recorded and automatically linked to their customer record.
    /// </summary>
    public class CertExpressInvitationModel
    {
        /// <summary>
        /// A unique ID number representing this CertExpress invitation.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The unique ID number of the AvaTax company that sent this invitation.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// The email address to which this invitation was sent. If this invitation was presented as a weblink, this value will be null.
        /// </summary>
        public String recipient { get; set; }

        /// <summary>
        /// The unique code of the customer that received this invitation.
        /// Note: This field is case sensitive. To have exemption certificates apply, this value should
        /// be the same as the one passed to create a customer.
        /// </summary>
        public String customerCode { get; set; }

        /// <summary>
        /// The customer who received this invitation.
        /// </summary>
        public CustomerModel customer { get; set; }

        /// <summary>
        /// The attached cover letter object to this request.
        /// </summary>
        public CoverLetterModel coverLetter { get; set; }

        /// <summary>
        /// The status of the emails associated with this invitation. If this invitation was sent via email,
        /// this value will change to `Sent` when the email message has been sent.
        /// </summary>
        public String emailStatus { get; set; }

        /// <summary>
        /// True if this invitation contained a cover letter only.
        /// </summary>
        public Boolean? coverLettersOnly { get; set; }

        /// <summary>
        /// When an invitation is sent, it contains a list of exposure zones for which the customer is invited to upload
        /// their exemption certificates. This list contains the ID numbers of the exposure zones identified.
        ///  
        /// For a list of exposure zones, please call `ListCertificateExposureZones`.
        /// </summary>
        public List<Int32> exposureZones { get; set; }

        /// <summary>
        /// The list of exemption reasons identified by this CertExpress invitation.
        ///  
        /// For a list of reason codes, please call `ListCertificateExemptReasons`.
        /// </summary>
        public List<Int32> exemptReasons { get; set; }

        /// <summary>
        /// Indicates the method that was used to deliver this CertExpress invitation.
        /// </summary>
        public CertificateRequestDeliveryMethod? deliveryMethod { get; set; }

        /// <summary>
        /// The custom message delivered with this invitation.
        /// </summary>
        public String message { get; set; }

        /// <summary>
        /// The date of the invitation.
        /// </summary>
        public DateTime? date { get; set; }

        /// <summary>
        /// The web link (URL) that a customer can click on or visit to begin using this CertExpress invitation.
        ///  
        /// This value is only usable if the status of this invitation is `Ready` and the request was created with type `Download`.
        /// NOTE: This link usually takes a few minutes to be available.
        /// </summary>
        public String requestLink { get; set; }


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
