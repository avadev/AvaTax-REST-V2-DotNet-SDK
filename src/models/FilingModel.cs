using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a listing of all tax calculation data for filings and for accruing to future filings.
    /// </summary>
    public class FilingModel
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
        public Byte? month { get; set; }

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
        /// A listing of regional tax filings within this time period.
        /// </summary>
        public List<FilingRegionModel> filingRegions { get; set; }


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
