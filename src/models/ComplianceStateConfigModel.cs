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
    /// A flattened model for State Config.
    /// </summary>
    public class ComplianceStateConfigModel
    {
        /// <summary>
        /// The Id of the StateConfig.
        /// </summary>
        public Int64? stateConfigId { get; set; }

        /// <summary>
        /// The Effective Date
        /// </summary>
        public DateTime? effDate { get; set; }

        /// <summary>
        /// The End Date
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// Has Boundary
        /// </summary>
        public Boolean? hasBoundary { get; set; }

        /// <summary>
        /// Has Rates
        /// </summary>
        public Boolean? hasRates { get; set; }

        /// <summary>
        /// Is Local Admin
        /// </summary>
        public Boolean? isLocalAdmin { get; set; }

        /// <summary>
        /// Is Local Nexus
        /// </summary>
        public Boolean? isLocalNexus { get; set; }

        /// <summary>
        /// IsSerState
        /// </summary>
        public Boolean? isSerState { get; set; }

        /// <summary>
        /// Min Boundary LevelId
        /// </summary>
        public Int32? minBoundaryLevelId { get; set; }

        /// <summary>
        /// Sst Status Id
        /// </summary>
        public Int32? sstStatusId { get; set; }

        /// <summary>
        /// Short name of State.
        /// </summary>
        public String state { get; set; }

        /// <summary>
        /// StateFips
        /// </summary>
        public String stateFips { get; set; }

        /// <summary>
        /// The name of the State.
        /// </summary>
        public String stateName { get; set; }

        /// <summary>
        /// Boundary Table BaseName
        /// </summary>
        public String boundaryTableBaseName { get; set; }

        /// <summary>
        /// STJCount
        /// </summary>
        public Int32? stjCount { get; set; }

        /// <summary>
        /// TsState Id
        /// </summary>
        public String tsStateId { get; set; }

        /// <summary>
        /// The name of the country.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// IsJaasEnabled
        /// </summary>
        public Int32? isJaasEnabled { get; set; }

        /// <summary>
        /// The name of the country.
        /// </summary>
        public Boolean? hasSSTBoundary { get; set; }

        /// <summary>
        /// The name of the country.
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
