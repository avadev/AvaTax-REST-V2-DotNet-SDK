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
    /// A job associated with a certificate.
    ///  
    /// Used as both the input shape on certificate POST/PUT (only `id` and the nested
    /// Avalara.AvaTax.AccountServices.Models.v2.CertificateJobModel.phases ids are required to link existing jobs/phases/tasks to the certificate)
    /// and the response shape on certificate GET endpoints when `jobs` is requested via
    /// `$include`. Use `$include=jobs.phases` or `$include=jobs.tasks` on GET to
    /// additionally populate the nested Avalara.AvaTax.AccountServices.Models.v2.CertificateJobModel.phases collection and the tasks under each phase.
    /// </summary>
    public class CertificateJobModel
    {
        /// <summary>
        /// Indicates whether this job was explicitly linked to the certificate.
        /// Populated by CertCapture on GET responses; ignored on POST/PUT.
        /// </summary>
        public Boolean? isExplicit { get; set; }

        /// <summary>
        /// Indicates whether this is a direct association.
        /// Populated by CertCapture on GET responses; ignored on POST/PUT.
        /// </summary>
        public Boolean? isDirect { get; set; }

        /// <summary>
        /// The unique ID of this job. Required on POST/PUT to link an existing job to the certificate.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The name of this job. Populated by CertCapture on GET responses; ignored on POST/PUT
        /// (the job is identified by Avalara.AvaTax.AccountServices.Models.v2.CertificateJobModel.id).
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The job number. Populated by CertCapture on GET responses; ignored on POST/PUT
        /// (the job is identified by Avalara.AvaTax.AccountServices.Models.v2.CertificateJobModel.id).
        /// </summary>
        public String jobNumber { get; set; }

        /// <summary>
        /// The name of the exposure zone associated with this job. Populated by CertCapture on
        /// GET responses; ignored on POST/PUT.
        /// </summary>
        public String exposureZoneName { get; set; }

        /// <summary>
        /// The nested list of phases for this job (each phase containing its own tasks).
        ///  
        /// On GET, populated by CertCapture only when `$include=jobs.phases` or
        /// `$include=jobs.tasks` is requested; null otherwise. On POST/PUT, supply the
        /// phase / task `id` values to link them to the certificate alongside the job.
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
