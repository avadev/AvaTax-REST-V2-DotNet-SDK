using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

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
    [Guid("dd6509cd-77b0-4dee-b6c7-b97c4dd64f57")]
    [ComVisible(true)]
    /// <summary>
    /// Address Resolution Model
    /// </summary>    
    public class AddressResolutionModel
    {
        [DispId(1)]
        /// <summary>
        /// The original address
        /// </summary>
        public AddressInfo address { get; set; }
        [DispId(2)]
        /// <summary>
        /// The validated address or addresses
        /// </summary>
        public List<ValidatedAddressInfo> validatedAddresses { get; set; }

        [DispId(3)]
        /// <summary>
        /// The geospatial coordinates of this address
        /// </summary>
        public CoordinateInfo coordinates { get; set; }

        [DispId(4)]
        /// <summary>
        /// The resolution quality of the geospatial coordinates
        /// </summary>
        public ResolutionQuality? resolutionQuality { get; set; }

        [DispId(5)]
        /// <summary>
        /// List of informational and warning messages regarding this address
        /// </summary>
        public List<TaxAuthorityInfo> taxAuthorities { get; set; }

        [DispId(6)]
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
