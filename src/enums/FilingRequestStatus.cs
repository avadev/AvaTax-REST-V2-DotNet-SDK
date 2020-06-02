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
    /// Filing Request Status types
    /// </summary>
    public enum FilingRequestStatus
    {
        /// <summary>
        /// Customer is building a request for a new filing calendar
        /// </summary>
        New = 1,

        /// <summary>
        /// Customer’s information validated before submitting to go live. All required information as per state and form selection is entered.
        /// </summary>
        Validated = 2,

        /// <summary>
        /// Customer submitted a request for a new filing calendar
        /// </summary>
        Pending = 3,

        /// <summary>
        /// Filing calender is active
        /// </summary>
        Active = 4,

        /// <summary>
        /// Customer requested to deactivate filing calendar
        /// </summary>
        PendingStop = 5,

        /// <summary>
        /// Filing calendar is inactive
        /// </summary>
        Inactive = 6,

        /// <summary>
        /// This indicates that there is a new change request.
        /// </summary>
        ChangeRequest = 7,

        /// <summary>
        /// This indicates that the change request was approved.
        /// </summary>
        RequestApproved = 8,

        /// <summary>
        /// This indicates that compliance rejected the request.
        /// </summary>
        RequestDenied = 9,

    }
}
