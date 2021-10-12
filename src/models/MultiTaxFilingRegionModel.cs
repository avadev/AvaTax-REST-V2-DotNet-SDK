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
    /// Regions
    /// </summary>
    public class MultiTaxFilingRegionModel
    {
        /// <summary>
        /// The two-character ISO-3166 code for the country.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The two or three character region code for the region.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// Whether or not you have nexus in this region.
        /// </summary>
        public Boolean? hasNexus { get; set; }

        /// <summary>
        /// The current status of the filing region.
        /// </summary>
        public FilingStatusId? status { get; set; }

        /// <summary>
        /// A summary of all taxes compbined for this period
        /// </summary>
        public FilingsTaxSummaryModel regionTaxSummary { get; set; }

        /// <summary>
        /// A detailed breakdown of the taxes in this filing
        /// </summary>
        public List<FilingsTaxDetailsModel> regionTaxDetails { get; set; }

        /// <summary>
        /// A list of tax returns in this region.
        /// </summary>
        public List<FilingsCheckupSuggestedFormModel> suggestReturns { get; set; }

        /// <summary>
        /// A list of tax returns in this region.
        /// </summary>
        public List<MultiTaxFilingReturnModel> returns { get; set; }


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
