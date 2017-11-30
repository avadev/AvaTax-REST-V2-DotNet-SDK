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
    /// Indicates whether Avalara Managed Returns has begun filing for this company.
    /// </summary>
    public enum CompanyFilingStatus
    {
        /// <summary>
        /// This company is not a reporting entity and cannot file taxes. To change this behavior, you must mark
        ///  the company as a reporting entity.
        /// </summary>
        NoReporting,

        /// <summary>
        /// This company is a reporting entity, but Avalara is not currently filing tax returns for this company.
        /// </summary>
        NotYetFiling,

        /// <summary>
        /// The customer has requested that Avalara Managed Returns begin filing for this company, however filing has
        ///  not yet started. Avalara's compliance team is reviewing this request and will update the company to
        ///  first filing status when complete.
        /// </summary>
        FilingRequested,

        /// <summary>
        /// Avalara has begun filing tax returns for this company. Normally, this status will change to `Active` after 
        ///  one month of successful filing of tax returns.
        /// </summary>
        FirstFiling,

        /// <summary>
        /// Avalara currently files tax returns for this company.
        /// </summary>
        Active,

        /// <summary>
        /// This company has not been configured for compliance
        /// </summary>
        NotConfiguredForCompliance,

    }
}
