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
    /// 
    /// </summary>
    public enum BatchType
    {
        /// <summary>
        /// 
        /// </summary>
        AvaCertUpdate = 0,

        /// <summary>
        /// 
        /// </summary>
        AvaCertUpdateAll = 1,

        /// <summary>
        /// 
        /// </summary>
        BatchMaintenance = 2,

        /// <summary>
        /// 
        /// </summary>
        CompanyLocationImport = 3,

        /// <summary>
        /// 
        /// </summary>
        DocumentImport = 4,

        /// <summary>
        /// 
        /// </summary>
        ExemptCertImport = 5,

        /// <summary>
        /// 
        /// </summary>
        ItemImport = 6,

        /// <summary>
        /// 
        /// </summary>
        SalesAuditExport = 7,

        /// <summary>
        /// 
        /// </summary>
        SstpTestDeckImport = 8,

        /// <summary>
        /// 
        /// </summary>
        TaxRuleImport = 9,

        /// <summary>
        /// 
        /// </summary>
        TransactionImport = 10,

        /// <summary>
        /// 
        /// </summary>
        UPCBulkImport = 11,

        /// <summary>
        /// 
        /// </summary>
        UPCValidationImport = 12,

    }
}
