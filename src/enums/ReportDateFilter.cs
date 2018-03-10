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
    /// The date filter type for report
    ///  "RD" for Reporting Date, "DD" for Document Date, "TD" for Tax Date, "PD" for Payment Date
    /// </summary>
    public enum ReportDateFilter
    {
        /// <summary>
        /// The date when the transaction is posted
        /// </summary>
        DocumentDate,

        /// <summary>
        /// The date when the transaction is paid for
        /// </summary>
        PaymentDate,

        /// <summary>
        /// The date when the transaction is added to report
        /// </summary>
        ReportingDate,

        /// <summary>
        /// The date when the transaction is being taxed
        /// </summary>
        TaxDate,

    }
}
