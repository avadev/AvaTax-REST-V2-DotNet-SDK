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
    /// Represents the Country coefficients model, using which tax rules rates can be modified dynamically for CB transaciotns while applying tax rules
    /// in order to reduce the variance for all the transactions at country level.
    /// </summary>
    public class CountryCoefficientsRequestModel
    {
        /// <summary>
        /// CompanyCode
        /// </summary>
        public String companyCode { get; set; }

        /// <summary>
        /// The country for which coefficient will be applied.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// Value by which rates need to be altered while calculating taxes.
        /// </summary>
        public Decimal coefficient { get; set; }

        /// <summary>
        /// TaxSubTypeId
        /// </summary>
        public String taxSubTypeId { get; set; }

        /// <summary>
        /// CurrencyCode
        /// </summary>
        public String currencyCode { get; set; }

        /// <summary>
        /// UnitOfBasisId
        /// </summary>
        public Int32 unitOfBasisId { get; set; }

        /// <summary>
        /// IsApplicable
        /// Flag that is being used to mark the effectiveness of the specific entry for the particular date.
        /// </summary>
        public Boolean isApplicable { get; set; }

        /// <summary>
        /// StartDate
        /// </summary>
        public DateTime startDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime endDate { get; set; }


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
