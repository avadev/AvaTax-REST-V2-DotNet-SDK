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
 * Swagger name: AvaTaxClient 
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// The output DocumentType for a report
    /// </summary>
    public enum ReportDocType
    {
        /// <summary>
        /// Output all ConsumerUse tax transactions in the report
        /// </summary>
        ConsumerUse = 67,

        /// <summary>
        /// Output all Sales tax transactions in the report
        /// </summary>
        Sales = 83,

    }
}
