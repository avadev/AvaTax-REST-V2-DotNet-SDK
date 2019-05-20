using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
    /// Information about all the addresses involved in this transaction.
    ///  
    /// For a physical in-person transaction at a retail point-of-sale location, please specify only one address using
    /// the `singleLocation` field.
    ///  
    /// For a transaction that was shipped, delivered, or provided from an origin location such as a warehouse to
    /// a destination location such as a customer, please specify the `shipFrom` and `shipTo` addresses.
    ///  
    /// In the United States, some jurisdictions recognize the address types `pointOfOrderOrigin` and `pointOfOrderAcceptance`.
    /// These address types affect the sourcing models of some transactions.
    ///  
    /// If latitude and longitude information is provided for any of these addresses along with line, city, region, country and postal code information,
    /// we will be using only latitude and longitude and will discard line, city, region, country and postal code information for the transaction.
    /// Please ensure that you have the correct latitude/longitude information for the addresses prior to using the API.
    /// If you provide either latitude or longitude information but not both, we will be using the line, city, region, country and postal code information for the addresses.
    /// </summary>
    public class AddressesModel
    {
        /// <summary>
        /// If this transaction occurred at a retail point-of-sale location, provide that single address here and leave
        /// all other address types null.
        /// </summary>
        public AddressLocationInfo singleLocation { get; set; }

        /// <summary>
        /// The origination address where the products were shipped from, or from where the services originated.
        /// </summary>
        public AddressLocationInfo shipFrom { get; set; }

        /// <summary>
        /// The destination address where the products were shipped to, or where the services were delivered.
        /// </summary>
        public AddressLocationInfo shipTo { get; set; }

        /// <summary>
        /// The place of business where you receive the customer's order. This address type is valid in the United States only
        /// and only applies to tangible personal property.
        /// </summary>
        public AddressLocationInfo pointOfOrderOrigin { get; set; }

        /// <summary>
        /// The place of business where you accept/approve the customer’s order,
        /// thereby becoming contractually obligated to make the sale. This address type is valid in the United States only
        /// and only applies to tangible personal property.
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
