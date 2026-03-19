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
    /// Represents a VAT Number record for a company.
    /// </summary>
    public class CustomerVatNumberModel
    {
        /// <summary>
        /// Unique identifier for the VAT number record
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// Company ID associated with this VAT number
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// VAT identification number
        /// </summary>
        public String vatNumber { get; set; }

        /// <summary>
        /// User input business/company name
        /// </summary>
        public String businessName { get; set; }

        /// <summary>
        /// ISO 2-character country code
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// VAT number validation status: 0=NotValidated, 1=Valid, 2=Invalid, 3=Error
        /// </summary>
        public Int32? vatNumberStatus { get; set; }

        /// <summary>
        /// Business name returned from VIES
        /// </summary>
        public String registeredBusinessName { get; set; }

        /// <summary>
        /// Business name comparison status: 0=NotValidated, 1=Valid, 2=Invalid, 3=Error
        /// </summary>
        public Int32? businessNameStatus { get; set; }

        /// <summary>
        /// Last validation timestamp
        /// </summary>
        public DateTime? validationDate { get; set; }

        /// <summary>
        /// Validation source: 'VIES' or 'ELR'
        /// </summary>
        public String validationSource { get; set; }

        /// <summary>
        /// Date/time when this record was created
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// Date/time when this record was last modified
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
