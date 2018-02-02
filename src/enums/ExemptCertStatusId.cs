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
    /// Status for this exempt certificate
    /// </summary>
    public enum ExemptCertStatusId
    {
        /// <summary>
        /// Inactive certificate
        /// </summary>
        Inactive,

        /// <summary>
        /// Active certificate
        /// </summary>
        Active,

        /// <summary>
        /// Expired certificate
        /// </summary>
        Expired,

        /// <summary>
        /// Revoked certificate
        /// </summary>
        Revoked,

    }
}
