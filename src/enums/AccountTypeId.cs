using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2023 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Jonathan Wenger <jonathan.wenger@avalara.com>
 * @author Sachin Baijal <sachin.baijal@avalara.com>
 * Swagger name: AvaTaxClient 
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
