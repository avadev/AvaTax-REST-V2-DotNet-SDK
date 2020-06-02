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
        NoAccess = 0,

        /// <summary>
        /// SiteAdmin
        /// </summary>
        SiteAdmin = 1,

        /// <summary>
        /// AccountOperator
        /// </summary>
        AccountOperator = 2,

        /// <summary>
        /// AccountAdmin
        /// </summary>
        AccountAdmin = 3,

        /// <summary>
        /// AccountUser
        /// </summary>
        AccountUser = 4,

        /// <summary>
        /// SystemAdmin
        /// </summary>
        SystemAdmin = 5,

        /// <summary>
        /// Registrar
        /// </summary>
        Registrar = 6,

        /// <summary>
        /// CSPTester
        /// </summary>
        CSPTester = 7,

        /// <summary>
        /// CSPAdmin
        /// </summary>
        CSPAdmin = 8,

        /// <summary>
        /// SystemOperator
        /// </summary>
        SystemOperator = 9,

        /// <summary>
        /// TechnicalSupportUser
        /// </summary>
        TechnicalSupportUser = 10,

        /// <summary>
        /// TechnicalSupportAdmin
        /// </summary>
        TechnicalSupportAdmin = 11,

        /// <summary>
        /// TreasuryUser
        /// </summary>
        TreasuryUser = 12,

        /// <summary>
        /// TreasuryAdmin
        /// </summary>
        TreasuryAdmin = 13,

        /// <summary>
        /// ComplianceUser
        /// </summary>
        ComplianceUser = 14,

        /// <summary>
        /// ComplianceAdmin
        /// </summary>
        ComplianceAdmin = 15,

        /// <summary>
        /// ProStoresOperator
        /// </summary>
        ProStoresOperator = 16,

        /// <summary>
        /// CompanyUser
        /// </summary>
        CompanyUser = 17,

        /// <summary>
        /// CompanyAdmin
        /// </summary>
        CompanyAdmin = 18,

        /// <summary>
        /// ComplianceTempUser
        /// </summary>
        ComplianceTempUser = 19,

        /// <summary>
        /// ComplianceRootUser
        /// </summary>
        ComplianceRootUser = 20,

        /// <summary>
        /// ComplianceOperator
        /// </summary>
        ComplianceOperator = 21,

        /// <summary>
        /// SSTAdmin
        /// </summary>
        SSTAdmin = 22,

        /// <summary>
        /// FirmUser
        /// </summary>
        FirmUser = 23,

        /// <summary>
        /// FirmAdmin
        /// </summary>
        FirmAdmin = 24,

    }
}
