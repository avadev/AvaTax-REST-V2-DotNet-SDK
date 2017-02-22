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
    /// CompanyAccessLevel
    /// </summary>
    public enum CompanyAccessLevel
    {
        /// <summary>
        /// 
        /// </summary>
        None,

        /// <summary>
        /// 
        /// </summary>
        SingleCompany,

        /// <summary>
        /// 
        /// </summary>
        SingleAccount,

        /// <summary>
        /// 
        /// </summary>
        AllCompanies,

    }
}
