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
    /// DocumentType
    /// </summary>
    public enum DocumentType
    {
        /// <summary>
        /// 
        /// </summary>
        SalesOrder,

        /// <summary>
        /// 
        /// </summary>
        SalesInvoice,

        /// <summary>
        /// 
        /// </summary>
        PurchaseOrder,

        /// <summary>
        /// 
        /// </summary>
        PurchaseInvoice,

        /// <summary>
        /// 
        /// </summary>
        ReturnOrder,

        /// <summary>
        /// 
        /// </summary>
        ReturnInvoice,

        /// <summary>
        /// 
        /// </summary>
        InventoryTransferOrder,

        /// <summary>
        /// 
        /// </summary>
        InventoryTransferInvoice,

        /// <summary>
        /// 
        /// </summary>
        ReverseChargeOrder,

        /// <summary>
        /// 
        /// </summary>
        ReverseChargeInvoice,

        /// <summary>
        /// 
        /// </summary>
        Any,

    }
}
