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
 * @author Greg Hester
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
        ConsumerUse,

        /// <summary>
        /// Output all Sales tax transactions in the report
        /// </summary>
        Sales,

    }
}
