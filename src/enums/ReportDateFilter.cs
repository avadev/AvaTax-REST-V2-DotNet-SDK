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
    /// The date filter type for report
    ///  "RD" for Reporting Date, "DD" for Document Date, "TD" for Tax Date, "PD" for Payment Date
    /// </summary>
    public enum ReportDateFilter
    {
        /// <summary>
        /// The date when the transaction is posted
        /// </summary>
        DocumentDate = 68,

        /// <summary>
        /// The date when the transaction is modified
        /// </summary>
        ModifiedDate = 77,

        /// <summary>
        /// The date when the transaction is paid for
        /// </summary>
        PaymentDate = 80,

        /// <summary>
        /// The date when the transaction is added to report
        /// </summary>
        ReportingDate = 82,

        /// <summary>
        /// The date when the transaction is being taxed
        /// </summary>
        TaxDate = 84,

    }
}
