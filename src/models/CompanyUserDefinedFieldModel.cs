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
 * Swagger name: AvaTaxClient
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// 
    /// </summary>
    public class CompanyUserDefinedFieldModel
    {
        /// <summary>
        /// The id of the datasource.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The id of the company to which the datasource belongs to.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// The extractor/connector id.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The unique ID number of this connection.
        /// </summary>
        public String friendlyName { get; set; }

        /// <summary>
        /// The unique ID number of this connection.
        /// </summary>
        public UserDefinedFieldDataType? dataType { get; set; }

        /// <summary>
        /// The category of user defined type For Example: Document level or Line level UDF.
        /// </summary>
        public UserDefinedFieldType? userDefinedFieldType { get; set; }

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
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
