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
    /// Data source object
    /// </summary>
    public class DataSourceModel
    {
        /// <summary>
        /// The id of the datasource.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The id of the company to which the datasource belongs to.
        /// </summary>
        public Int32 companyId { get; set; }

        /// <summary>
        /// The extractor/connector id.
        /// </summary>
        public String source { get; set; }

        /// <summary>
        /// The unique ID number of this connection.
        /// </summary>
        public String instance { get; set; }

        /// <summary>
        /// The connection using the connection_id is enabled. The customer is responsible to enable or disable.
        /// </summary>
        public Boolean? isEnabled { get; set; }

        /// <summary>
        /// If all the information has been transferred from the extractor to the database.
        /// </summary>
        public Boolean? isSynced { get; set; }

        /// <summary>
        /// True if this data source is authorized.
        /// </summary>
        public Boolean? isAuthorized { get; set; }

        /// <summary>
        /// The date when the information was last synched.
        /// </summary>
        public DateTime? lastSyncedDate { get; set; }

        /// <summary>
        /// The User ID of the user who created this record.
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// The date when this record was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The user ID of the user who last modified this record.
        /// </summary>
        public Int32? modifiedUserId { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// The date when this record was deleted.
        /// </summary>
        public DateTime? deletedDate { get; set; }

        /// <summary>
        /// Specifies whether transactions created by this data source needs to re-calculate tax or not
        /// </summary>
        public Boolean? recalculate { get; set; }

        /// <summary>
        /// Specifies the name of the extractor
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Specifies any implementation-specific information along with the DataSource.This field has no internal meaning in AvaTax and is purely for the convenience of the DataSource API user
        /// </summary>
        public String externalState { get; set; }


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
