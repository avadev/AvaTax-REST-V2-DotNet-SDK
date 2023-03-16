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
    /// This object represents a single determination factor for a line that is being inspected through the InspectLine API.
    /// </summary>
    public class DeterminationFactorModel
    {
        /// <summary>
        /// Determination reason code.
        /// </summary>
        public String code { get; set; }

        /// <summary>
        /// Determination reason description.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// The ids of any applied determination factor.
        /// </summary>
        public List<String> ids { get; set; }

        /// <summary>
        /// The name of any applied determination factor.
        /// </summary>
        public List<String> names { get; set; }

        /// <summary>
        /// The name of the user who created the determination factor.
        /// </summary>
        public String createdBy { get; set; }


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
