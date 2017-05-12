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
    /// Permission level of a user
    /// </summary>
    public enum SecurityRoleId
    {
        /// <summary>
        /// NoAccess
        /// </summary>
        NoAccess,

        /// <summary>
        /// SiteAdmin
        /// </summary>
        SiteAdmin,

        /// <summary>
        /// AccountOperator
        /// </summary>
        AccountOperator,

        /// <summary>
        /// AccountAdmin
        /// </summary>
        AccountAdmin,

        /// <summary>
        /// AccountUser
        /// </summary>
        AccountUser,

        /// <summary>
        /// SystemAdmin
        /// </summary>
        SystemAdmin,

        /// <summary>
        /// Registrar
        /// </summary>
        Registrar,

        /// <summary>
        /// CSPTester
        /// </summary>
        CSPTester,

        /// <summary>
        /// CSPAdmin
        /// </summary>
        CSPAdmin,

        /// <summary>
        /// SystemOperator
        /// </summary>
        SystemOperator,

        /// <summary>
        /// TechnicalSupportUser
        /// </summary>
        TechnicalSupportUser,

        /// <summary>
        /// TechnicalSupportAdmin
        /// </summary>
        TechnicalSupportAdmin,

        /// <summary>
        /// TreasuryUser
        /// </summary>
        TreasuryUser,

        /// <summary>
        /// TreasuryAdmin
        /// </summary>
        TreasuryAdmin,

        /// <summary>
        /// ComplianceUser
        /// </summary>
        ComplianceUser,

        /// <summary>
        /// ComplianceAdmin
        /// </summary>
        ComplianceAdmin,

        /// <summary>
        /// ProStoresOperator
        /// </summary>
        ProStoresOperator,

        /// <summary>
        /// CompanyUser
        /// </summary>
        CompanyUser,

        /// <summary>
        /// CompanyAdmin
        /// </summary>
        CompanyAdmin,

        /// <summary>
        /// ComplianceTempUser
        /// </summary>
        ComplianceTempUser,

        /// <summary>
        /// ComplianceRootUser
        /// </summary>
        ComplianceRootUser,

        /// <summary>
        /// ComplianceOperator
        /// </summary>
        ComplianceOperator,

        /// <summary>
        /// SSTAdmin
        /// </summary>
        SSTAdmin,

    }
}
