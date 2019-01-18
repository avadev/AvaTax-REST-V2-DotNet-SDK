using System;

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
    /// The way of delivering request
    /// </summary>
    public enum CertificateRequestDeliveryMethod
    {
        /// <summary>
        /// The invitation will be sent via email to the recipient's email address.
        /// </summary>
        Email = 1,

        /// <summary>
        /// The invitation will be sent via facsimile to the recipient's facsimile phone number.
        ///  
        ///  Facsimile transmission make take time to process and deliver via phone lines.
        /// </summary>
        Fax = 2,

        /// <summary>
        /// The request will be processed and turned into a web link (URL) which the user can click on to visit the CertExpress site and immediately
        ///  begin entering data about their certificates.
        /// </summary>
        Download = 3,

    }
}
