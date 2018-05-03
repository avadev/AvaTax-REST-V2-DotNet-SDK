using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
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
    /// Address Resolution Model
    /// </summary>
    public class AddressResolutionModel
    {
        /// <summary>
        /// The original address
        /// </summary>
        public AddressInfo address { get; set; }

        /// <summary>
        /// The validated address or addresses
        /// </summary>
        public List<ValidatedAddressInfo> validatedAddresses { get; set; }

        /// <summary>
        /// The geospatial coordinates of this address
        /// </summary>
        public CoordinateInfo coordinates { get; set; }

        /// <summary>
        /// The resolution quality of the geospatial coordinates
        /// </summary>
        public ResolutionQuality? resolutionQuality { get; set; }

        /// <summary>
        /// If AvaTax is able to calculate tax for a given address.
        /// </summary>
        public Boolean? ableToCalculateTax { get; set; }

        /// <summary>
        /// List of informational and warning messages regarding this address
        /// </summary>
        public List<TaxAuthorityInfo> taxAuthorities { get; set; }

        /// <summary>
        /// List of informational and warning messages regarding this address
        /// </summary>
        public List<AvaTaxMessage> messages { get; set; }


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
