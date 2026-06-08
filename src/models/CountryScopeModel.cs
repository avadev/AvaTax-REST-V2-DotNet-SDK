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
    /// Restricts automated classification to all nexus countries or an explicit list.
    /// </summary>
    public class CountryScopeModel
    {
        /// <summary>
        /// Avalara.ItemMasterCoreService.Common.ClassificationSettingsConstants.CountryScopeTypes.All or Avalara.ItemMasterCoreService.Common.ClassificationSettingsConstants.CountryScopeTypes.Selected.
        /// </summary>
        public String type { get; set; }

        /// <summary>
        /// ISO 3166 alpha-2 codes when `type` is `selected`; ignored for `all`.
        /// </summary>
        public List<String> countries { get; set; }


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
