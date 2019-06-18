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
    /// Tax Details by Tax subtype
    /// </summary>
    public class TaxDetailsByTaxSubType
    {
        /// <summary>
        /// Tax subtype
        /// </summary>
        public String taxSubType { get; set; }

        /// <summary>
        /// Total taxable amount by tax type
        /// </summary>
        public Decimal? totalTaxable { get; set; }

        /// <summary>
        /// Total exempt by tax type
        /// </summary>
        public Decimal? totalExempt { get; set; }

        /// <summary>
        /// Total non taxable by tax type
        /// </summary>
        public Decimal? totalNonTaxable { get; set; }

        /// <summary>
        /// Total tax by tax type
        /// </summary>
        public Decimal? totalTax { get; set; }


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
