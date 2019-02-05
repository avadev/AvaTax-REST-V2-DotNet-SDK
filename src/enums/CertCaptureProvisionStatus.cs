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
    /// 
    /// </summary>
    public enum CertCaptureProvisionStatus
    {
        /// <summary>
        /// Account and company are provisioned
        /// </summary>
        Provisioned = 0,

        /// <summary>
        /// Provision job is being queued
        ///  This could also be an indication that some companies under an account has been provisioned, while others
        ///  under the same account has not.
        /// </summary>
        InProgress = 1,

        /// <summary>
        /// 
        /// </summary>
        NotProvisioned = 2,

    }
}
