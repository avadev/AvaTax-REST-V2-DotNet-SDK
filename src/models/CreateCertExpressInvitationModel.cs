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
    public class CreateCertExpressInvitationModel
    {
        /// <summary>
        /// If the value of `deliveryMethod` is set to `Email`, please specify the email address of the recipient
        /// for the request.
        /// </summary>
        public String recipient { get; set; }

        /// <summary>
        /// If this invitation is sent via email or download, please specify the cover letter to use when building this
        /// invitation. For a list of cover letters, please call `ListCoverLetters`.
        /// </summary>
        public String coverLetterTitle { get; set; }

        /// <summary>
        /// You may optionally specify a list of exposure zones to request in this CertExpress invitation. If you list
        /// more than one exposure zone, the customer will be prompted to provide an exemption certificate for each one.
        /// If you do not provide a list of exposure zones, the customer will be prompted to select an exposure zone.
        ///  
        /// For a list of available exposure zones, please call `ListCertificateExposureZones`.
        /// </summary>
        public List<Int32> exposureZones { get; set; }

        /// <summary>
        /// You may optionally specify a list of exemption reasons to pre-populate in this CertExpress invitation.
        /// If you list exemption reasons, the customer will have part of their form already filled in when they visit
        /// the CertExpress website.
        ///  
        /// For a list of available exemption reasons, please call `ListCertificateExemptReasons`.
        /// </summary>
        public List<Int32> exemptReasons { get; set; }

        /// <summary>
        /// Specify the type of invitation. CertExpress invitations can be delivered via email, web link, or
        /// facsimile.
        ///  
        /// * If you specify `Email`, the invitation will be delivered via email. Please ask the customer to ensure that
        /// * If you specify `Fax`, the invitation will be sent via fax to the customer's fax number on file.
        /// * If you specify `Download`, the invitation will be prepared as a web link that you can display to the customer.
        /// </summary>
        public CertificateRequestDeliveryMethod? deliveryMethod { get; set; }


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
