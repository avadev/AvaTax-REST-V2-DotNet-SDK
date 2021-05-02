using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Simple POCO  + ToString() object to hold the tax information returned by the BuildTaxContentFileForLocationAsync 
    /// methods in AvaTaxClient 
    /// </summary>
    /// 
    /// <remarks>
    /// Josh Waldrep - jwaldrepwork@gmail.com - 04/2021
    /// The datatypes here were derived from the response to the api route "/api/v2/companies/{companyId}/locations/{id}/pointofsaledata" 
    /// and need to be reviewed and commented.
    /// </remarks>
    public class LocationTaxContent
    {
        public Int32? ScenarioId { get; set; }
        public DateTime? EffDate { get; set; }
        public DateTime? EndDate { get; set; }
        public String LocationCode { get; set; }
        public String TaxCode { get; set; }
        public String ShipToCity { get; set; }
        public String ShipToCounty { get; set; }
        public String ShipToState { get; set; }
        public String ShipToPostalCode { get; set; }
        public String ShipToCountry { get; set; }
        public String JurisType { get; set; }
        public String JurisName { get; set; }
        public String TaxType { get; set; }
        public String Tax_Description { get; set; }
        public decimal? Tax_Rate { get; set; }
        public String Cap { get; set; }
        public String Threshold { get; set; }
        public String TaxRuleOptions { get; set; }

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
