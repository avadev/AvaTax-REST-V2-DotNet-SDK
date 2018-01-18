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
    /// Filing Status
    /// </summary>
    public enum FilingStatusId
    {
        /// <summary>
        /// 
        /// </summary>
        PendingApproval,

        /// <summary>
        /// 
        /// </summary>
        Dirty,

        /// <summary>
        /// 
        /// </summary>
        ApprovedToFile,

        /// <summary>
        /// 
        /// </summary>
        PendingFiling,

        /// <summary>
        /// 
        /// </summary>
        PendingFilingOnBehalf,

        /// <summary>
        /// 
        /// </summary>
        Filed,

        /// <summary>
        /// 
        /// </summary>
        FiledOnBehalf,

        /// <summary>
        /// 
        /// </summary>
        ReturnAccepted,

        /// <summary>
        /// 
        /// </summary>
        ReturnAcceptedOnBehalf,

        /// <summary>
        /// 
        /// </summary>
        PaymentRemitted,

        /// <summary>
        /// 
        /// </summary>
        Voided,

        /// <summary>
        /// 
        /// </summary>
        PendingReturn,

        /// <summary>
        /// 
        /// </summary>
        PendingReturnOnBehalf,

        /// <summary>
        /// 
        /// </summary>
        DoNotFile,

        /// <summary>
        /// 
        /// </summary>
        ReturnRejected,

        /// <summary>
        /// 
        /// </summary>
        ReturnRejectedOnBehalf,

        /// <summary>
        /// 
        /// </summary>
        ApprovedToFileOnBehalf,

    }
}
