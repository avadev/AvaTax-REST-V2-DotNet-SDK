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
    /// Indicates the level of companies that can be accessed
    /// </summary>
    public enum CompanyAccessLevel
    {
        /// <summary>
        /// No permission to access companies.
        /// </summary>
        None = 0,

        /// <summary>
        /// Permission to access a single company and its children.
        /// </summary>
        SingleCompany = 1,

        /// <summary>
        /// Permission to access all companies in a single account.
        /// </summary>
        SingleAccount = 2,

        /// <summary>
        /// Permission to access all companies in all accounts. Reserved for system administration tasks.
        /// </summary>
        AllCompanies = 3,

        /// <summary>
        /// Permission to access all companies in all accounts managed by a firm account.
        /// </summary>
        FirmManagedAccounts = 4,

    }
}
