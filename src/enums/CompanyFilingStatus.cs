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
    /// 
    /// </summary>
    public enum CompanyFilingStatus
    {
        /// <summary>
        /// 
        /// </summary>
        NotConfiguredForCompliance = 0,

        /// <summary>
        /// 
        /// </summary>
        NotYetFiling = 1,

        /// <summary>
        /// 
        /// </summary>
        FilingRequested = 2,

        /// <summary>
        /// 
        /// </summary>
        FirstFiling = 3,

        /// <summary>
        /// 
        /// </summary>
        Active = 4,

        /// <summary>
        /// 
        /// </summary>
        NoReporting = 5,

        /// <summary>
        /// 
        /// </summary>
        Inactive = 6,

    }
}
