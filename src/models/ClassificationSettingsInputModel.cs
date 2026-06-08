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
    /// Request body for creating company classification settings (`POST /classification-settings`).
    /// </summary>
    public class ClassificationSettingsInputModel
    {
        /// <summary>
        /// Classification mode: typically Avalara.ItemMasterCoreService.Common.ClassificationSettingsConstants.Modes.AutoFull or Avalara.ItemMasterCoreService.Common.ClassificationSettingsConstants.Modes.AutoPartial.
        /// </summary>
        public String mode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ClassificationCriteriaModel criteria { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CountryScopeModel countryScope { get; set; }


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
