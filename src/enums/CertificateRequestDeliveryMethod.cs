using System;

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
    /// The way of delivering request
    /// </summary>
    public enum CertificateRequestDeliveryMethod
    {
        /// <summary>
        /// Emailing the request to recipients
        /// </summary>
        Email,

        /// <summary>
        /// Faxing the request to recipients
        /// </summary>
        Fax,

        /// <summary>
        /// Downloading the request
        /// </summary>
        Download,

    }
}
