using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Filing Frequency types
    /// </summary>
    public enum NoticeCustomerType
    {
        /// <summary>
        /// AvaTax Returns
        /// </summary>
        AvaTaxReturns,

        /// <summary>
        /// Stand Alone
        /// </summary>
        StandAlone,

        /// <summary>
        /// Strategic
        /// </summary>
        Strategic,

        /// <summary>
        /// SST
        /// </summary>
        SST,

        /// <summary>
        /// TrustFile
        /// </summary>
        TrustFile,

    }
}
