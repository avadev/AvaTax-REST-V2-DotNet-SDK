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
    /// Indicates the level of companies that can be accessed
    /// </summary>
    public enum CompanyAccessLevel
    {
        /// <summary>
        /// No permission to access companies.
        /// </summary>
        None,

        /// <summary>
        /// Permission to access a single company and its children.
        /// </summary>
        SingleCompany,

        /// <summary>
        /// Permission to access all companies in a single account.
        /// </summary>
        SingleAccount,

        /// <summary>
        /// Permission to access all companies in all accounts. Reserved for system administration tasks.
        /// </summary>
        AllCompanies,

    }
}
