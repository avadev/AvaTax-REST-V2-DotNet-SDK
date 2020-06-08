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
    /// Marketplace Location Output model
    /// </summary>
    public class MarketplaceLocationModel
    {
        /// <summary>
        /// Marketplace Location State
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// Marketplace Location Country
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// Marketplace Location Id
        /// </summary>
        public String marketplaceId { get; set; }

        /// <summary>
        /// Marketplace Location
        /// </summary>
        public String marketplace { get; set; }

        /// <summary>
        /// Marketplace Location Adoption Date
        /// </summary>
        public DateTime? marketplaceAdoptionDate { get; set; }

        /// <summary>
        /// Marketplace Location End Date
        /// </summary>
        public DateTime? marketplaceEndDate { get; set; }

        /// <summary>
        /// Marketplace Location Legislative Effective Date
        /// </summary>
        public DateTime? legislativeEffectiveDate { get; set; }

        /// <summary>
        /// Marketplace Location Enforcement Date
        /// </summary>
        public DateTime? enforcementDate { get; set; }

        /// <summary>
        /// Marketplace Location Created Date
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// Marketplace Location Modified Date
        /// </summary>
        public DateTime? modifiedDate { get; set; }


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
