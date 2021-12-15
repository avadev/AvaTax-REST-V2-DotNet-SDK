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
    /// Represents a tax rule product detail that changes the behavior of Avalara's tax engine for certain tax rules.
    ///  
    /// Avalara supports a two types of tax product detail. For information about tax rule Product Types
    /// HSCode and TaxCode
    ///  
    /// Because different types of tax rules have different behavior, some fields may change their behavior based on
    /// the type of tax rule selected. Please read the documentation for each field carefully and ensure that
    /// the value you send is appropriate for the type of tax rule.
    /// </summary>
    public class TaxRuleProductDetailModel
    {
        /// <summary>
        /// The unique ID number of this Tax rule product detail.
        /// </summary>
        public Int32? taxRuleProductDetailId { get; set; }

        /// <summary>
        /// TaxRule Id of TaxRule Product Detail entry
        /// </summary>
        public Int32? taxRuleId { get; set; }

        /// <summary>
        /// Product Code value
        /// </summary>
        public String productCode { get; set; }

        /// <summary>
        /// The first date at which this product detail applies. If `null`, this product detail will apply to all dates prior to the end date.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// The last date for which this product detail applies. If `null`, this product detail will apply to all dates after the effective date.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// Represents the system Id the detail is applicable for.
        /// </summary>
        public Int32? systemId { get; set; }


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
