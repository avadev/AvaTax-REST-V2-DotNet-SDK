using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2023 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Jonathan Wenger <jonathan.wenger@avalara.com>
 * @author Sachin Baijal <sachin.baijal@avalara.com>
 * Swagger name: AvaTaxClient 
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// 
    /// </summary>
    public enum DeliveryTerms
    {
        /// <summary>
        /// Delivery At Place (DAP) implies that Duty And Tax will be paid by the Buyer or Consignee of the shipment
        /// </summary>
        DAP = 1,

        /// <summary>
        /// Delivery Duty Paid (DDP) implies that Duty And Tax will be paid by the Shipper
        /// </summary>
        DDP = 2,

        /// <summary>
        /// Free on Board
        /// </summary>
        FOB = 3,

        /// <summary>
        /// Free Carrier
        /// </summary>
        FCA = 4,

        /// <summary>
        /// Free Alongside Ship
        /// </summary>
        FAS = 5,

        /// <summary>
        /// Ex Works
        /// </summary>
        EXW = 6,

        /// <summary>
        /// Delivered at Place Unloaded
        /// </summary>
        DPU = 7,

        /// <summary>
        /// Carriage Paid To
        /// </summary>
        CPT = 8,

        /// <summary>
        /// Carriage Insurance Paid To
        /// </summary>
        CIP = 9,

        /// <summary>
        /// Cost, Insurance, and Freight
        /// </summary>
        CIF = 10,

        /// <summary>
        /// Cost And Freight
        /// </summary>
        CFR = 11,

    }
}
