using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
    /// Represents additional information for vendor
    /// </summary>
    public class VendorAdditionalInfoModel
    {
        /// <summary>
        /// The unique ID number of this vendor additional info record.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The ID of the vendor (customer) this additional information is associated with.
        /// </summary>
        public Int32? vendorId { get; set; }

        /// <summary>
        /// The identifier for the cost center associated with this vendor.
        /// </summary>
        public Int64? costCenterId { get; set; }

        /// <summary>
        /// The cost center code associated with this vendor.
        /// </summary>
        public String costCenterCode { get; set; }

        /// <summary>
        /// The identifier for the item code associated with this vendor.
        /// </summary>
        public Int64? itemCodeId { get; set; }

        /// <summary>
        /// The item code associated with this vendor.
        /// </summary>
        public String itemCode { get; set; }

        /// <summary>
        /// The default tax exemption for this vendor.
        /// </summary>
        public String defaultTaxExemption { get; set; }

        /// <summary>
        /// The ID of the ship-from location for this vendor.
        /// </summary>
        public Int32? shipFromLocationId { get; set; }

        /// <summary>
        /// The code identifying the ship-from location for this vendor.
        /// </summary>
        public String shipFromLocationCode { get; set; }

        /// <summary>
        /// Street address line of the ship-from location for this vendor.
        /// </summary>
        public String shipFromAddressLine { get; set; }

        /// <summary>
        /// City component of the ship-from address for this vendor.
        /// </summary>
        public String shipFromAddressCity { get; set; }

        /// <summary>
        /// State or region component of the ship-from address for this vendor.
        /// </summary>
        public String shipFromAddressState { get; set; }

        /// <summary>
        /// Postal code / zip code component of the ship-from address for this vendor.
        /// </summary>
        public String shipFromAddressZip { get; set; }

        /// <summary>
        /// Country component of the ship-from address for this vendor.
        /// </summary>
        public String shipFromAddressCountry { get; set; }

        /// <summary>
        /// The unique ID of the ship-to location for this vendor.
        /// </summary>
        public Int32? shipToLocationId { get; set; }

        /// <summary>
        /// The code identifying the ship-to location for this vendor.
        /// </summary>
        public String shipToLocationCode { get; set; }

        /// <summary>
        /// Street address line of the ship-to location for this vendor.
        /// </summary>
        public String shipToAddressLine { get; set; }

        /// <summary>
        /// City component of the ship-to address for this vendor.
        /// </summary>
        public String shipToAddressCity { get; set; }

        /// <summary>
        /// State or region component of the ship-to address for this vendor.
        /// </summary>
        public String shipToAddressState { get; set; }

        /// <summary>
        /// Postal code / zip code component of the ship-to address for this vendor.
        /// </summary>
        public String shipToAddressZip { get; set; }

        /// <summary>
        /// Country component of the ship-to address for this vendor.
        /// </summary>
        public String shipToAddressCountry { get; set; }

        /// <summary>
        /// This value is `true` if this vendor is marked as a trusted vendor.
        /// </summary>
        public Boolean? isTrustedVendor { get; set; }

        /// <summary>
        /// This value is `true` if accrual accounting is enabled for this vendor.
        /// </summary>
        public Boolean? isAccrual { get; set; }

        /// <summary>
        /// This value is `true` if tax liability is on the vendor rather than the purchaser.
        /// </summary>
        public Boolean? isTaxOnVendor { get; set; }


        /// <summary>
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
