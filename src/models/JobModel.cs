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
    /// A job associated with a certificate or customer. Used for $include=jobs on certificate/customer
    /// fetch APIs, and as the request/response body for the standalone Jobs CRUD endpoints.
    /// </summary>
    public class JobModel
    {
        /// <summary>
        /// The unique ID number of this job.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The job number of this job.
        /// </summary>
        public String jobNumber { get; set; }

        /// <summary>
        /// The name of this job.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The date when this job was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The date when this job was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ExposureZoneModel exposureZone { get; set; }

        /// <summary>
        /// A list of phases associated with this job.
        ///  
        /// You can fetch this data by specifying `$include=phases` when calling a job fetch API.
        /// Use `$include=phases,tasks` to also expand the tasks within each phase.
        /// </summary>
        public List<JobPhaseModel> phases { get; set; }


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
