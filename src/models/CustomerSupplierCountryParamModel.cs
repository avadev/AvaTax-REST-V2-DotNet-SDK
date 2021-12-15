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
    /// Represents a parameter associated with a company.
    /// </summary>
    public class CustomerSupplierCountryParamModel
    {
        /// <summary>
        /// Identifier for company parameter
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// CompanyId associated with the parameter
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// Identifier for company parameter
        /// </summary>
        public Int64? customerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String customerCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Boolean? isEstablished { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String businessIdentificationNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Boolean? isRegisteredThroughFiscalRep { get; set; }


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
