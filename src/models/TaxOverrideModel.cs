using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
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
    /// Represents a tax override for a transaction
    /// </summary>
    public class TaxOverrideModel
    {
        /// <summary>
        /// Identifies the type of tax override
        /// </summary>
        public TaxOverrideType? type { get; set; }

        /// <summary>
        /// Indicates a total override of the calculated tax on the document. AvaTax will distribute
        /// the override across all the lines.
        ///  
        /// Tax will be distributed on a best effort basis. It may not always be possible to override all taxes. Please consult
        /// your account manager for information about overrides.
        /// </summary>
        public Decimal? taxAmount { get; set; }

        /// <summary>
        /// The override tax date to use
        ///  
        /// This is used when the tax has been previously calculated
        /// as in the case of a layaway, return or other reason indicated by the Reason element.
        /// If the date is not overridden, then it should be set to the same as the DocDate.
        /// </summary>
        public DateTime? taxDate { get; set; }

        /// <summary>
        /// This provides the reason for a tax override for audit purposes. It is required for types 2-4.
        ///  
        /// Typical reasons include:
        /// "Return"
        /// "Layaway"
        /// </summary>
        public String reason { get; set; }


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
