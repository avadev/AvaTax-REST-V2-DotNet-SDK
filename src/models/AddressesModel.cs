using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
    /// A series of addresses information in a GetTax call
    /// </summary>
    public class AddressesModel
    {
        /// <summary>
        /// If this transaction occurred at a retail point-of-sale location, use this
        /// </summary>
        public AddressLocationInfo singleLocation { get; set; }

        /// <summary>
        /// If this transaction was shipped from a warehouse location to a customer location, specify both "ShipFrom" and "ShipTo".
        /// </summary>
        public AddressLocationInfo shipFrom { get; set; }

        /// <summary>
        /// If this transaction was shipped from a warehouse location to a customer location, specify both "ShipFrom" and "ShipTo".
        /// </summary>
        public AddressLocationInfo shipTo { get; set; }

        /// <summary>
        /// The place of business where you receive the customer's order.
        /// </summary>
        public AddressLocationInfo pointOfOrderOrigin { get; set; }

        /// <summary>
        /// The place of business where you accept/approve the customer’s order,
        /// thereby becoming contractually obligated to make the sale.
        /// </summary>
        public AddressLocationInfo pointOfOrderAcceptance { get; set; }


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
