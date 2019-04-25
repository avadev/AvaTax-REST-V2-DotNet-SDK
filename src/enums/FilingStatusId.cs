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
    /// Filing Status
    /// </summary>
    public enum FilingStatusId
    {
        /// <summary>
        /// Filing is pending approval
        /// </summary>
        PendingApproval = 0,

        /// <summary>
        /// Transactions are being updated
        /// </summary>
        Dirty = 1,

        /// <summary>
        /// Approved for filing
        /// </summary>
        ApprovedToFile = 2,

        /// <summary>
        /// Pending filing
        /// </summary>
        PendingFiling = 3,

        /// <summary>
        /// Pending and iled on behalf of userr 
        /// </summary>
        PendingFilingOnBehalf = 4,

        /// <summary>
        /// Filed
        /// </summary>
        Filed = 5,

        /// <summary>
        /// Filed on behalf of user
        /// </summary>
        FiledOnBehalf = 6,

        /// <summary>
        /// Return accepted
        /// </summary>
        ReturnAccepted = 7,

        /// <summary>
        /// Return accepted on behalf of user
        /// </summary>
        ReturnAcceptedOnBehalf = 8,

        /// <summary>
        /// Payment remitted
        /// </summary>
        PaymentRemitted = 9,

        /// <summary>
        /// Filing voided
        /// </summary>
        Voided = 10,

        /// <summary>
        /// Return pending
        /// </summary>
        PendingReturn = 11,

        /// <summary>
        /// Return pending on behalf of user
        /// </summary>
        PendingReturnOnBehalf = 12,

        /// <summary>
        /// Do not file 
        /// </summary>
        DoNotFile = 13,

        /// <summary>
        /// Return rejected
        /// </summary>
        ReturnRejected = 14,

        /// <summary>
        /// Return rejected on behalf of user
        /// </summary>
        ReturnRejectedOnBehalf = 15,

        /// <summary>
        /// Aproved to file on behalf of user
        /// </summary>
        ApprovedToFileOnBehalf = 16,

    }
}
