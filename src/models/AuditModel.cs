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
    /// Provides detailed information about an API call.
    /// </summary>
    public class AuditModel
    {
        /// <summary>
        /// The transaction id
        /// </summary>
        public Int64? transactionId { get; set; }

        /// <summary>
        /// The account id
        /// </summary>
        public Int32? accountId { get; set; }

        /// <summary>
        /// The user id
        /// </summary>
        public Int32? userId { get; set; }

        /// <summary>
        /// The IP address
        /// </summary>
        public String ipAddress { get; set; }

        /// <summary>
        /// The machine name
        /// </summary>
        public String machineName { get; set; }

        /// <summary>
        /// The client name
        /// </summary>
        public String clientName { get; set; }

        /// <summary>
        /// The client version
        /// </summary>
        public String clientVersion { get; set; }

        /// <summary>
        /// The adapter name
        /// </summary>
        public String adapterName { get; set; }

        /// <summary>
        /// The adapter version
        /// </summary>
        public String adapterVersion { get; set; }

        /// <summary>
        /// The server name
        /// </summary>
        public String serverName { get; set; }

        /// <summary>
        /// The server version
        /// </summary>
        public String serverVersion { get; set; }

        /// <summary>
        /// The reference id
        /// </summary>
        public Int64? referenceId { get; set; }

        /// <summary>
        /// The severity level id
        /// </summary>
        public Byte[] severityLevelId { get; set; }

        /// <summary>
        /// The server timestamp
        /// </summary>
        public DateTime? serverTimestamp { get; set; }

        /// <summary>
        /// The server duration
        /// </summary>
        public Int32? serverDuration { get; set; }

        /// <summary>
        /// The service name
        /// </summary>
        public String serviceName { get; set; }

        /// <summary>
        /// The operation
        /// </summary>
        public String operation { get; set; }

        /// <summary>
        /// The reference code
        /// </summary>
        public String referenceCode { get; set; }

        /// <summary>
        /// The error message
        /// </summary>
        public String errorMessage { get; set; }

        /// <summary>
        /// The audit message
        /// </summary>
        public String auditMessage { get; set; }

        /// <summary>
        /// The load balancer duration
        /// </summary>
        public Int32? lbDuration { get; set; }

        /// <summary>
        /// The record count
        /// </summary>
        public Int32? recordCount { get; set; }

        /// <summary>
        /// The reference authorization
        /// </summary>
        public String referenceAuthorization { get; set; }

        /// <summary>
        /// Whether or not it is queued
        /// </summary>
        public Boolean? isQueued { get; set; }

        /// <summary>
        /// The number of calls to the database
        /// </summary>
        public Int32? databaseCallCount { get; set; }

        /// <summary>
        /// The time to make a call to the database
        /// </summary>
        public String databaseCallDuration { get; set; }

        /// <summary>
        /// The time to receive a response from a remote server
        /// </summary>
        public String remoteCallDuration { get; set; }

        /// <summary>
        /// Audit events
        /// </summary>
        public List<AuditEvent> events { get; set; }

        /// <summary>
        /// The request url
        /// </summary>
        public String requestUrl { get; set; }

        /// <summary>
        /// The request body
        /// </summary>
        public String requestBody { get; set; }

        /// <summary>
        /// The resposne status
        /// </summary>
        public Int32? responseStatus { get; set; }

        /// <summary>
        /// The response body
        /// </summary>
        public String responseBody { get; set; }

        /// <summary>
        /// The remote calls
        /// </summary>
        public List<AuditModel> remoteCalls { get; set; }


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
