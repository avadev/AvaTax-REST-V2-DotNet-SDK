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
    /// Data source object
    /// </summary>
    public class DataSourceModel
    {
        /// <summary>
        /// ToDo
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// ToDo
        /// </summary>
        public Int32 companyId { get; set; }

        /// <summary>
        /// ToDo
        /// </summary>
        public String connectorId { get; set; }

        /// <summary>
        /// ToDo
        /// </summary>
        public String connectionId { get; set; }

        /// <summary>
        /// ToDo
        /// </summary>
        public Boolean? isEnabled { get; set; }

        /// <summary>
        /// ToDo
        /// </summary>
        public Boolean? isSynced { get; set; }

        /// <summary>
        /// ToDo
        /// </summary>
        public Boolean? isAuthorized { get; set; }

        /// <summary>
        /// ToDo
        /// </summary>
        public DateTime? lastSyncedDate { get; set; }

        /// <summary>
        /// ToDo
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// ToDo
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// ToDo
        /// </summary>
        public Int32? modifiedUserId { get; set; }

        /// <summary>
        /// ToDo
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// ToDo
        /// </summary>
        public DateTime? deletedDate { get; set; }


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
