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
    /// 
    /// </summary>
    public enum CertCaptureProvisionStatus
    {
        /// <summary>
        /// Account and company are provisioned
        /// </summary>
        Provisioned,

        /// <summary>
        /// Provision job is being queued
        ///  This could also be an indication that some companies under an account has been provisioned, while others
        ///  under the same account has not.
        /// </summary>
        InProgress,

        /// <summary>
        /// 
        /// </summary>
        NotProvisioned,

    }
}
