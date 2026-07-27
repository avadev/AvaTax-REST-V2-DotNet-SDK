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
    /// A phase within a certificate job.
    /// </summary>
    public class JobPhaseModel
    {
        /// <summary>
        /// The unique ID number of this phase.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The name of this phase.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The ID of the job this phase belongs to.
        /// </summary>
        public Int32? jobId { get; set; }

        /// <summary>
        /// The unique code for this phase.
        /// </summary>
        public String phaseCode { get; set; }

        /// <summary>
        /// The date when this phase was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The date when this phase was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// A list of tasks within this phase.
        /// </summary>
        public List<JobTaskModel> tasks { get; set; }


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
