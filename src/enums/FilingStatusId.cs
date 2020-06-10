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
        /// 
        /// </summary>
        PendingApproval = 0,

        /// <summary>
        /// 
        /// </summary>
        Dirty = 1,

        /// <summary>
        /// 
        /// </summary>
        ApprovedToFile = 2,

        /// <summary>
        /// 
        /// </summary>
        PendingFiling = 3,

        /// <summary>
        /// 
        /// </summary>
        PendingFilingOnBehalf = 4,

        /// <summary>
        /// 
        /// </summary>
        Filed = 5,

        /// <summary>
        /// 
        /// </summary>
        FiledOnBehalf = 6,

        /// <summary>
        /// 
        /// </summary>
        ReturnAccepted = 7,

        /// <summary>
        /// 
        /// </summary>
        ReturnAcceptedOnBehalf = 8,

        /// <summary>
        /// 
        /// </summary>
        PaymentRemitted = 9,

        /// <summary>
        /// 
        /// </summary>
        Voided = 10,

        /// <summary>
        /// 
        /// </summary>
        PendingReturn = 11,

        /// <summary>
        /// 
        /// </summary>
        PendingReturnOnBehalf = 12,

        /// <summary>
        /// 
        /// </summary>
        DoNotFile = 13,

        /// <summary>
        /// 
        /// </summary>
        ReturnRejected = 14,

        /// <summary>
        /// 
        /// </summary>
        ReturnRejectedOnBehalf = 15,

        /// <summary>
        /// 
        /// </summary>
        ApprovedToFileOnBehalf = 16,

    }
}
