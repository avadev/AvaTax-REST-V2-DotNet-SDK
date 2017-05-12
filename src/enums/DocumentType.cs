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
    /// Document Types
    /// </summary>
    public enum DocumentType
    {
        /// <summary>
        /// Sales Order, estimate or quote (default). This is a temporary document type and is not saved in tax history.
        /// </summary>
        SalesOrder,

        /// <summary>
        /// Sales Invoice
        /// </summary>
        SalesInvoice,

        /// <summary>
        /// Purchase order, estimate, or quote. This is a temporary document type and is not saved in tax history.
        /// </summary>
        PurchaseOrder,

        /// <summary>
        /// Purchase Invoice
        /// </summary>
        PurchaseInvoice,

        /// <summary>
        /// Sales Return Order. This is a temporary document type and is not saved in tax history.
        /// </summary>
        ReturnOrder,

        /// <summary>
        /// Sales Return Invoice
        /// </summary>
        ReturnInvoice,

        /// <summary>
        /// InventoryTransferOrder
        /// </summary>
        InventoryTransferOrder,

        /// <summary>
        /// InventoryTransferInvoice
        /// </summary>
        InventoryTransferInvoice,

        /// <summary>
        /// ReverseChargeOrder
        /// </summary>
        ReverseChargeOrder,

        /// <summary>
        /// ReverseChargeInvoice
        /// </summary>
        ReverseChargeInvoice,

        /// <summary>
        /// No particular type
        /// </summary>
        Any,

    }
}
