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
    /// Represents a customer with its country parameter information.
    /// This model combines CustomerSupplier and CustomerSupplierCountryParam data.
    /// </summary>
    public class CustomerSupplierWithCountryParamModel
    {
        /// <summary>
        /// Customer ID
        /// </summary>
        public Int64? customerId { get; set; }

        /// <summary>
        /// Customer Code
        /// </summary>
        public String customerCode { get; set; }

        /// <summary>
        /// Company ID
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// Customer Type ID (1=Customer, 2=Supplier)
        /// </summary>
        public Int32? customerTypeId { get; set; }

        /// <summary>
        /// Customer Supplier Country Parameter ID
        /// </summary>
        public Int64? customerSupplierCountryParamId { get; set; }

        /// <summary>
        /// Country code
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// Whether the customer is established in this country
        /// </summary>
        public Boolean? isEstablished { get; set; }

        /// <summary>
        /// Business Identification Number
        /// </summary>
        public String businessIdentificationNo { get; set; }

        /// <summary>
        /// Whether registered through fiscal representative
        /// </summary>
        public Boolean? isRegisteredThroughFiscalRep { get; set; }

        /// <summary>
        /// VAT number for the customer in this country
        /// </summary>
        public String vatNumber { get; set; }

        /// <summary>
        /// Status of VAT number validation (0=NotValidated, 1=Valid, 2=Invalid, 3=Unverifiable, 4=ValidationError, 5=UnsupportedCountry)
        /// </summary>
        public Int32? vatNumberStatus { get; set; }


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
