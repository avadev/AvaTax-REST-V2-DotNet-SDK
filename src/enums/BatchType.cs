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
    /// BatchType
    /// </summary>
    public enum BatchType
    {
        /// <summary>
        /// 
        /// </summary>
        AvaCertUpdate,

        /// <summary>
        /// 
        /// </summary>
        AvaCertUpdateAll,

        /// <summary>
        /// 
        /// </summary>
        BatchMaintenance,

        /// <summary>
        /// 
        /// </summary>
        CompanyLocationImport,

        /// <summary>
        /// 
        /// </summary>
        DocumentImport,

        /// <summary>
        /// 
        /// </summary>
        ExemptCertImport,

        /// <summary>
        /// 
        /// </summary>
        ItemImport,

        /// <summary>
        /// 
        /// </summary>
        SalesAuditExport,

        /// <summary>
        /// 
        /// </summary>
        SstpTestDeckImport,

        /// <summary>
        /// 
        /// </summary>
        TaxRuleImport,

        /// <summary>
        /// 
        /// </summary>
        TransactionImport,

        /// <summary>
        /// 
        /// </summary>
        UPCBulkImport,

        /// <summary>
        /// 
        /// </summary>
        UPCValidationImport,

    }
}
