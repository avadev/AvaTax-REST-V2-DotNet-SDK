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
    /// Indicates whether Avalara Managed Returns has begun filing for this company.
    /// </summary>
    public enum CompanyFilingStatus
    {
        /// <summary>
        /// This company has not been configured for compliance
        /// </summary>
        NotConfiguredForCompliance = 0,

        /// <summary>
        /// This company is a reporting entity, but Avalara is not currently filing tax returns for this company.
        /// </summary>
        NotYetFiling = 1,

        /// <summary>
        /// The customer has requested that Avalara Managed Returns begin filing for this company, however filing has
        ///  not yet started. Avalara's compliance team is reviewing this request and will update the company to
        ///  first filing status when complete.
        /// </summary>
        FilingRequested = 2,

        /// <summary>
        /// Avalara has begun filing tax returns for this company. Normally, this status will change to `Active` after
        ///  one month of successful filing of tax returns.
        /// </summary>
        FirstFiling = 3,

        /// <summary>
        /// Avalara currently files tax returns for this company.
        /// </summary>
        Active = 4,

        /// <summary>
        /// This company is not a reporting entity and cannot file taxes. To change this behavior, you must mark
        ///  the company as a reporting entity.
        /// </summary>
        NoReporting = 5,

        /// <summary>
        /// This company is inactive
        /// </summary>
        Inactive = 6,

    }
}
