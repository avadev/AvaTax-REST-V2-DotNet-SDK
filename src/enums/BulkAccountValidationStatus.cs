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
    /// A list of bulk account validation statuses for filing calendars.
    /// </summary>
    public enum BulkAccountValidationStatus
    {
        /// <summary>
        /// 
        /// </summary>
        New = 0,

        /// <summary>
        /// 
        /// </summary>
        Added = 1,

        /// <summary>
        /// 
        /// </summary>
        Failed = 2,

    }
}
