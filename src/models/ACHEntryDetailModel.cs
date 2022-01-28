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
    /// An edit to be made on a filing calendar.
    /// </summary>
    public class ACHEntryDetailModel
    {
        /// <summary>
        /// Company Id
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// Company Name
        /// </summary>
        public String companyName { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public String state { get; set; }

        /// <summary>
        /// State Region
        /// </summary>
        public String stateRegion { get; set; }

        /// <summary>
        /// Individual Id
        /// </summary>
        public String individualId { get; set; }

        /// <summary>
        /// IndividualName
        /// </summary>
        public String individualName { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public Decimal? amount { get; set; }

        /// <summary>
        /// TraceNumber
        /// </summary>
        public String traceNumber { get; set; }


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
