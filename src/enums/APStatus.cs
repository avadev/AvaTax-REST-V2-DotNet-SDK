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
        NoAccrualMatch = 0,

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
        NoAccrualUndercharge = 4,

        /// <summary>
        /// 
        /// </summary>
        AccruedUndercharge = 5,

        /// <summary>
        /// 
        /// </summary>
        ShortPayItemsAccrueUndercharge = 6,

        /// <summary>
        /// 
        /// </summary>
        NeedReviewUndercharge = 7,

        /// <summary>
        /// 
        /// </summary>
        RejectUndercharge = 8,

        /// <summary>
        /// 
        /// </summary>
        NoAccrualOvercharge = 9,

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
        NoAccrualAmountThresholdNotMet = 14,

        /// <summary>
        /// 
        /// </summary>
        NoAccrualExemptedCostCenter = 15,

        /// <summary>
        /// 
        /// </summary>
        NoAccrualExemptedItem = 16,

        /// <summary>
        /// 
        /// </summary>
        NoAccrualTrustedVendor = 17,

        /// <summary>
        /// 
        /// </summary>
        AccruedVendor = 18,

        /// <summary>
        /// 
        /// </summary>
        NeedReviewVendor = 19,

        /// <summary>
        /// 
        /// </summary>
        NoAccrualExemptedVendor = 20,

        /// <summary>
        /// 
        /// </summary>
        NoAccrualExemptedGLAccount = 21,

        /// <summary>
        /// 
        /// </summary>
        PendingAccrualVendor = 22,

        /// <summary>
        /// 
        /// </summary>
        PendingAccrualUndercharge = 23,

    }
}
