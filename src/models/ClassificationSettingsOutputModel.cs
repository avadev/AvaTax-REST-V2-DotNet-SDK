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
    /// API response for classification settings, including optimistic versioning and pipeline state.
    /// </summary>
    public class ClassificationSettingsOutputModel
    {
        /// <summary>
        /// Company that owns the settings row.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// Current classification mode.
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
        /// Monotonic settings version; increments when IMS updates the row.
        /// </summary>
        public Int32? settingsVersion { get; set; }

        /// <summary>
        /// `created` immediately after create/update from this API; downstream may set `processing` then `completed`.
        /// </summary>
        public String processingState { get; set; }

        /// <summary>
        /// Processing attempt counter aligned with downstream jobs.
        /// </summary>
        public Int32? processingVersion { get; set; }

        /// <summary>
        /// Set when IMS create/update last wrote the row (enters `created`).
        /// </summary>
        public DateTime? processingStartedDate { get; set; }

        /// <summary>
        /// Set by the downstream completion service when state becomes `completed`; null until then.
        /// </summary>
        public DateTime? processingCompletedDate { get; set; }

        /// <summary>
        /// Optional pipeline note (`processingnote` on `dbo.itemclassificationsettings`).
        /// </summary>
        public String processingNote { get; set; }

        /// <summary>
        /// User id that created the row.
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// UTC creation timestamp.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// User id for the last modification.
        /// </summary>
        public Int32? modifiedUserId { get; set; }

        /// <summary>
        /// UTC last modification timestamp.
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
