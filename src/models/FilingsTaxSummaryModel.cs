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
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a listing of all tax calculation data for filings and for accruing to future filings.
    /// </summary>
    public class FilingsTaxSummaryModel
    {
        /// <summary>
        /// The total sales amount
        /// </summary>
        public Decimal? salesAmount { get; set; }

        /// <summary>
        /// The taxable amount
        /// </summary>
        public Decimal? taxableAmount { get; set; }

        /// <summary>
        /// The nontaxable amount
        /// </summary>
        public Decimal? nonTaxableAmount { get; set; }

        /// <summary>
        /// The tax amount
        /// </summary>
        public Decimal? taxAmount { get; set; }

        /// <summary>
        /// The remittance amount
        /// </summary>
        public Decimal? remittanceAmount { get; set; }

        /// <summary>
        /// The collect amount
        /// </summary>
        public Decimal? collectAmount { get; set; }

        /// <summary>
        /// The sales accrual amount
        /// </summary>
        public Decimal? salesAccrualAmount { get; set; }

        /// <summary>
        /// The taxable sales accrual amount
        /// </summary>
        public Decimal? taxableAccrualAmount { get; set; }

        /// <summary>
        /// The nontaxable accrual amount
        /// </summary>
        public Decimal? nonTaxableAccrualAmount { get; set; }

        /// <summary>
        /// The tax accrual amount
        /// </summary>
        public Decimal? taxAccrualAmount { get; set; }


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
