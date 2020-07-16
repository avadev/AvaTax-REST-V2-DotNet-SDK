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
    public enum DocumentType
    {
        /// <summary>
        /// 
        /// </summary>
        SalesOrder = 0,

        /// <summary>
        /// 
        /// </summary>
        SalesInvoice = 1,

        /// <summary>
        /// 
        /// </summary>
        PurchaseOrder = 2,

        /// <summary>
        /// 
        /// </summary>
        PurchaseInvoice = 3,

        /// <summary>
        /// 
        /// </summary>
        ReturnOrder = 4,

        /// <summary>
        /// 
        /// </summary>
        ReturnInvoice = 5,

        /// <summary>
        /// 
        /// </summary>
        InventoryTransferOrder = 6,

        /// <summary>
        /// 
        /// </summary>
        InventoryTransferInvoice = 7,

        /// <summary>
        /// 
        /// </summary>
        ReverseChargeOrder = 8,

        /// <summary>
        /// 
        /// </summary>
        ReverseChargeInvoice = 9,

        /// <summary>
        /// 
        /// </summary>
        Any = -1,

    }
}
