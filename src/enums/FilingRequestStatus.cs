using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Filing Request Status types
    /// </summary>
    public enum FilingRequestStatus
    {
        /// <summary>
        /// Customer is building a request for a new filing calendar
        /// </summary>
        New,

        /// <summary>
        /// Customer’s information validated before submitting to go live. All required information as per state and form selection is entered.
        /// </summary>
        Validated,

        /// <summary>
        /// Customer submitted a request for a new filing calendar
        /// </summary>
        Pending,

        /// <summary>
        /// Filing calender is active
        /// </summary>
        Active,

        /// <summary>
        /// Customer requested to deactivate filing calendar
        /// </summary>
        PendingStop,

        /// <summary>
        /// Filing calendar is inactive
        /// </summary>
        Inactive,

        /// <summary>
        /// This indicates that there is a new change request.
        /// </summary>
        ChangeRequest,

        /// <summary>
        /// This indicates that the change request was approved.
        /// </summary>
        RequestApproved,

        /// <summary>
        /// This indicates that compliance rejected the request.
        /// </summary>
        RequestDenied,

    }
}
