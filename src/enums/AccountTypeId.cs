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
    /// Status of an Avalara account
    /// </summary>
    public enum AccountTypeId
    {
        /// <summary>
        /// Regular AvaTax account.
        /// </summary>
        Regular = 1,

        /// <summary>
        /// Firm account.
        /// </summary>
        Firm = 2,

        /// <summary>
        /// Client account created by firm.
        /// </summary>
        FirmClient = 3,

    }
}
