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
    /// The type of data contained in this batch
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
        /// This batch type represents tax transaction data being uploaded to AvaTax. Each line in the batch represents a single transaction
        ///  or a line in a multi-line transaction. For reference, see [Batched Transactions in REST v2](http://developer.avalara.com/blog/2016/10/24/batch-transaction-upload-in-rest-v2)
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
