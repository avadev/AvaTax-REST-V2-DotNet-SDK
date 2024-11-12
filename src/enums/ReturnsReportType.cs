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
    /// Defines returns report type.
    /// </summary>
    public enum ReturnsReportType
    {
        /// <summary>
        /// liability summary return detail hospitality
        /// </summary>
        LIABILITYSUMMARYRETURNDETAILHOSPITALITY = 0,

        /// <summary>
        /// liability summary return detail
        /// </summary>
        LIABILITYSUMMARYRETURNDETAIL = 1,

        /// <summary>
        /// liability carry over credit
        /// </summary>
        LIABILITYCARRYOVERCREDIT = 2,

    }
}
