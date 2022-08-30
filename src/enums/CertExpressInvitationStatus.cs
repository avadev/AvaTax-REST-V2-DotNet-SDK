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
 * Swagger name: AvaTaxClient 
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Indicates the status of a CertExpress invitation link.
    /// </summary>
    public enum CertExpressInvitationStatus
    {
        /// <summary>
        /// The CertExpress website is currently building a landing page for the customer. Please
        ///  wait about 10 seconds and fetch this request again to see when it will be ready.
        /// </summary>
        InProgress = 0,

        /// <summary>
        /// Indicates that the CertExpress invitation has been completed and is ready to use.
        /// </summary>
        Ready = 1,

    }
}
