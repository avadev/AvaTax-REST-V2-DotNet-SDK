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
    /// Represents a costCenter upload error model.
    /// </summary>
    public class CostCenterUploadErrorModel
    {
        /// <summary>
        /// Row index of a costCenter
        /// </summary>
        public Int32? rowIndex { get; set; }

        /// <summary>
        /// Cost Center name
        /// </summary>
        public String costCenterCode { get; set; }

        /// <summary>
        /// List of errors for against given costCenter name
        /// </summary>
        public List<String> errors { get; set; }


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
