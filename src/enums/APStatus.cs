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
    /// /// The user can set some tolerance or threshold limits inorder to take appropriate actions when
    ///  their transactions are above or below certain threshold limits.
    ///  Account Payable (AP) status code indicates an action that needs to be taken when the tolerance/threshold falls between certain range.
    /// </summary>
    public enum APStatus
    {
        /// <summary>
        /// 
        /// </summary>
        PayAsBilledMatch = 0,

        /// <summary>
        /// 
        /// </summary>
        ShortPayItemsAccrueMatch = 1,

        /// <summary>
        /// 
        /// </summary>
        MarkForReviewMatch = 2,

        /// <summary>
        /// 
        /// </summary>
        RejectMatch = 3,

        /// <summary>
        /// 
        /// </summary>
        PayAsBilledNoAccrual = 4,

        /// <summary>
        /// 
        /// </summary>
        PayAsBilledAccrueUndercharge = 5,

        /// <summary>
        /// 
        /// </summary>
        ShortPayItemsAccrueUndercharge = 6,

        /// <summary>
        /// 
        /// </summary>
        MarkForReviewUndercharge = 7,

        /// <summary>
        /// 
        /// </summary>
        RejectUndercharge = 8,

        /// <summary>
        /// 
        /// </summary>
        PayAsBilledOvercharge = 9,

        /// <summary>
        /// 
        /// </summary>
        ShortPayAvalaraCalculated = 10,

        /// <summary>
        /// 
        /// </summary>
        ShortPayItemsAccrueOvercharge = 11,

        /// <summary>
        /// 
        /// </summary>
        MarkForReviewOvercharge = 12,

        /// <summary>
        /// 
        /// </summary>
        RejectOvercharge = 13,

        /// <summary>
        /// 
        /// </summary>
        AmountThresholdNotMet = 14,

        /// <summary>
        /// 
        /// </summary>
        CostCenterExempted = 15,

        /// <summary>
        /// 
        /// </summary>
        ItemExempted = 16,

        /// <summary>
        /// 
        /// </summary>
        TrustedVendor = 17,

        /// <summary>
        /// 
        /// </summary>
        AccruedByVendor = 18,

        /// <summary>
        /// 
        /// </summary>
        Ignored = 19,

    }
}
