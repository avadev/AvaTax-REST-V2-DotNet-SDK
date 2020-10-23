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
    public class MultiTaxFilingModel
    {
        /// <summary>
        /// The unique ID number of this filing.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The unique ID number of the company for this filing.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// The month of the filing period for this tax filing.
        /// The filing period represents the year and month of the last day of taxes being reported on this filing.
        /// For example, an annual tax filing for Jan-Dec 2015 would have a filing period of Dec 2015.
        /// </summary>
        public Int32? month { get; set; }

        /// <summary>
        /// The year of the filing period for this tax filing.
        /// The filing period represents the year and month of the last day of taxes being reported on this filing.
        /// For example, an annual tax filing for Jan-Dec 2015 would have a filing period of Dec 2015.
        /// </summary>
        public Int16? year { get; set; }

        /// <summary>
        /// Indicates whether this is an original or an amended filing.
        /// </summary>
        public WorksheetTypeId? type { get; set; }

        /// <summary>
        /// A summary of all taxes combined for this period
        /// </summary>
        public  taxSummary { get; set; }

        /// <summary>
        /// A detailed breakdown of the taxes in this filing
        /// </summary>
        public List<> taxDetails { get; set; }

        /// <summary>
        /// A listing of regional tax filings within this time period.
        /// </summary>
        public List<> filingRegions { get; set; }


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
