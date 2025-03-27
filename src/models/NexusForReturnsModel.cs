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
    /// Reponse model for the returns specific nexus fetch API
    /// </summary>
    public class NexusForReturnsModel
    {
        /// <summary>
        /// The nexus's id
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// Company Id
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// For region nexus, the assigned id for the country.
        /// For country nexus, null.
        /// </summary>
        public Int32? assignedToCountryId { get; set; }

        /// <summary>
        /// The two character ISO-3166 country code of the country in which this company declared nexus.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The two or three character ISO region code of the region, state, or province in which this company declared nexus.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// Jurisdiction Name
        /// </summary>
        public String jurisName { get; set; }

        /// <summary>
        /// Nexus Tax Type Group
        /// </summary>
        public String nexusTaxTypeGroup { get; set; }

        /// <summary>
        /// Nexus Type
        /// </summary>
        public NexusTypeId? nexusTypeId { get; set; }

        /// <summary>
        /// Has Local Nexus?
        /// </summary>
        public Boolean? hasLocalNexus { get; set; }

        /// <summary>
        /// Local Nexus Tax Type or null if no local nexus
        /// </summary>
        public String localNexusType { get; set; }

        /// <summary>
        /// The id of the SST nexus record if there is one.
        /// </summary>
        public Int32? sstNexusId { get; set; }

        /// <summary>
        /// If has SST Nexus, the nexus type id of the nexus
        /// </summary>
        public String sstType { get; set; }

        /// <summary>
        /// Min the effective Date can be
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// Max the end date can be
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// SST Effective Date
        /// </summary>
        public DateTime? sstEffectiveDate { get; set; }

        /// <summary>
        /// SST End Date
        /// </summary>
        public DateTime? sstEndDate { get; set; }

        /// <summary>
        /// Has nexus parameter IsRemoteSeller?
        /// </summary>
        public Boolean? isRemoteSeller { get; set; }


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
