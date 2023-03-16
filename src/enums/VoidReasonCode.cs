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
    /// Reason code for voiding or cancelling a transaction
    /// </summary>
    public enum VoidReasonCode
    {
        /// <summary>
        /// Unspecified reason
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// Post operation failed - Document status will be changed to unposted
        /// </summary>
        PostFailed = 1,

        /// <summary>
        /// Document deleted - If committed, document status will be changed to Cancelled. If not committed, document will be
        ///  deleted.
        /// </summary>
        DocDeleted = 2,

        /// <summary>
        /// Document has been voided and DocStatus will be set to Cancelled
        /// </summary>
        DocVoided = 3,

        /// <summary>
        /// AdjustTax operation has been cancelled. Adjustment will be reversed.
        /// </summary>
        AdjustmentCancelled = 4,

    }
}
