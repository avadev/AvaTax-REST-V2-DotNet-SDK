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
 * Swagger name: AvaTaxClient
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// An address used within this transaction.
    /// </summary>
    public class TransactionAddressModel
    {
        /// <summary>
        /// The unique ID number of this address.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The unique ID number of the document to which this address belongs.
        /// </summary>
        public Int64? transactionId { get; set; }

        /// <summary>
        /// The boundary level at which this address was validated.
        /// </summary>
        public BoundaryLevel? boundaryLevel { get; set; }

        /// <summary>
        /// The first line of the address.
        /// </summary>
        public String line1 { get; set; }

        /// <summary>
        /// The second line of the address.
        /// </summary>
        public String line2 { get; set; }

        /// <summary>
        /// The third line of the address.
        /// </summary>
        public String line3 { get; set; }

        /// <summary>
        /// The city for the address.
        /// </summary>
        public String city { get; set; }

        /// <summary>
        /// The ISO 3166 region code. E.g., the second part of ISO 3166-2.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// The postal code or zip code for the address.
        /// </summary>
        public String postalCode { get; set; }

        /// <summary>
        /// The ISO 3166 country code
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The unique ID number of the tax region for this address.
        /// </summary>
        public Int32? taxRegionId { get; set; }

        /// <summary>
        /// Latitude for this address
        /// </summary>
        public String latitude { get; set; }

        /// <summary>
        /// Longitude for this address
        /// </summary>
        public String longitude { get; set; }

        /// <summary>
        /// List of all the qualified jurisdictions for the TaxRegionId.
        /// </summary>
        public List<JurisdictionModel> jurisdictions { get; set; }


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
