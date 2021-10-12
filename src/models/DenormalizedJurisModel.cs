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
    /// Represents information about a single legal taxing jurisdiction within a specific Avalara tax region.
    /// </summary>
    public class DenormalizedJurisModel
    {
        /// <summary>
        /// The jurisdiction's effective date.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// The jurisdiction's end date.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The jurisdiction's code.
        /// </summary>
        public String jurisCode { get; set; }

        /// <summary>
        /// The jurisdiction's id.
        /// </summary>
        public Int32? jurisdictionId { get; set; }

        /// <summary>
        /// The jurisdiction's type.
        /// </summary>
        public JurisdictionType? jurisType { get; set; }

        /// <summary>
        /// The jurisdiction's name.
        /// </summary>
        public String jurisName { get; set; }

        /// <summary>
        /// The state assigned code.
        /// </summary>
        public String stateAssignedCode { get; set; }

        /// <summary>
        /// The id of the tax authority.
        /// </summary>
        public Int32? taxAuthorityId { get; set; }

        /// <summary>
        /// The jurisdiction's region.
        /// This should exist on the TaxRegion, but in practice often doesn't.
        /// </summary>
        public String state { get; set; }

        /// <summary>
        /// The jurisdiction's country.
        /// This should exist on the TaxRegion, but in practice often doesn't.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The jurisdiction's county.
        /// This should exist on the TaxRegion, but in practice often doesn't.
        /// </summary>
        public String county { get; set; }

        /// <summary>
        /// The jurisdiction's city.
        /// This should exist on the TaxRegion, but in practice often doesn't.
        /// </summary>
        public String city { get; set; }


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
