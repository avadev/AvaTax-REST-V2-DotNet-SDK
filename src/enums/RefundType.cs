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
    /// RefundType
    /// </summary>
    public enum RefundType
    {
        /// <summary>
        /// 
        /// </summary>
        Full,

        /// <summary>
        /// 
        /// </summary>
        Partial,

        /// <summary>
        /// 
        /// </summary>
        TaxOnly,

        /// <summary>
        /// 
        /// </summary>
        Percentage,

    }
}
