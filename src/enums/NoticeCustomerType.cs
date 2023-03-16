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
    /// Notice Customer Types
    /// </summary>
    public enum NoticeCustomerType
    {
        /// <summary>
        /// AvaTax Returns
        /// </summary>
        AvaTaxReturns = 1,

        /// <summary>
        /// Stand Alone
        /// </summary>
        StandAlone = 2,

        /// <summary>
        /// Strategic
        /// </summary>
        Strategic = 3,

        /// <summary>
        /// SST
        /// </summary>
        SST = 4,

        /// <summary>
        /// TrustFile
        /// </summary>
        TrustFile = 5,

        /// <summary>
        /// PWC
        /// </summary>
        PWC = 6,

        /// <summary>
        /// Hudson Group
        /// </summary>
        HudsonGroup = 7,

        /// <summary>
        /// MRA
        /// </summary>
        MRA = 8,

        /// <summary>
        /// None
        /// </summary>
        None = 9,

    }
}
