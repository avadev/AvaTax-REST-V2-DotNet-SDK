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
    /// Cycle Safe Expiration results.
    /// </summary>
    public class FilingsCheckupAuthorityModel
    {
        /// <summary>
        /// Unique ID of the tax authority
        /// </summary>
        public Int32? taxAuthorityId { get; set; }

        /// <summary>
        /// Location Code of the tax authority
        /// </summary>
        public String locationCode { get; set; }

        /// <summary>
        /// Name of the tax authority
        /// </summary>
        public String taxAuthorityName { get; set; }

        /// <summary>
        /// Type Id of the tax authority
        /// </summary>
        public Int32? taxAuthorityTypeId { get; set; }

        /// <summary>
        /// Jurisdiction Id of the tax authority
        /// </summary>
        public Int32? jurisdictionId { get; set; }

        /// <summary>
        /// Amount of tax collected in this tax authority
        /// </summary>
        public Decimal? tax { get; set; }

        /// <summary>
        /// Tax Type collected in the tax authority
        /// </summary>
        public String taxTypeId { get; set; }

        /// <summary>
        /// Suggested forms to file due to tax collected
        /// </summary>
        public List<FilingsCheckupSuggestedFormModel> suggestedForms { get; set; }


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
