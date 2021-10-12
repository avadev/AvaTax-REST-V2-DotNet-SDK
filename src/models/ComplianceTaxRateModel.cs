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
    /// The tax rate model.
    /// </summary>
    public class ComplianceTaxRateModel
    {
        /// <summary>
        /// The unique id of the rate.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The tax rate.
        /// </summary>
        public Decimal? rate { get; set; }

        /// <summary>
        /// The id of the jurisdiction.
        /// </summary>
        public Int32? jurisdictionId { get; set; }

        /// <summary>
        /// The id of the tax region.
        /// </summary>
        public Int32? taxRegionId { get; set; }

        /// <summary>
        /// The date this rate is starts to take effect.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// The date this rate is no longer active.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The rate type.
        /// </summary>
        public String rateTypeId { get; set; }

        /// <summary>
        /// The tax type.
        /// </summary>
        public String taxTypeId { get; set; }

        /// <summary>
        /// The name of the tax.
        /// </summary>
        public String taxName { get; set; }

        /// <summary>
        /// The unit of basis.
        /// </summary>
        public Int64? unitOfBasisId { get; set; }

        /// <summary>
        /// The rate type tax type mapping id.
        /// </summary>
        public Int32? rateTypeTaxTypeMappingId { get; set; }


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
