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
    /// usage of system defined parameters.
    /// </summary>
    public class ParameterUsageModel
    {
        /// <summary>
        /// The unique ID number of this property.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The id of the parameter.
        /// </summary>
        public Int64? parameterId { get; set; }

        /// <summary>
        /// Product code for the parameter usage item.
        /// </summary>
        public String productCode { get; set; }

        /// <summary>
        /// The country for the parameter usage item.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The state for the parameter usage item.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// System Id for the parameter usage item
        /// </summary>
        public Int32? systemId { get; set; }

        /// <summary>
        /// tax type for the parameter usage item.
        /// </summary>
        public String taxTypeId { get; set; }

        /// <summary>
        /// The type of parameter as determined by its application, e.g. Product, Transaction, Calculated
        /// </summary>
        public String attributeType { get; set; }

        /// <summary>
        /// The name of the property. To use this property, add a field on the `parameters` object of a [CreateTransaction](https://developer.avalara.com/api-reference/avatax/rest/v2/methods/Transactions/CreateTransaction/) call.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The data type of the property.
        /// </summary>
        public String dataType { get; set; }

        /// <summary>
        /// Help text to be shown to the user when they are filling out this parameter. Help text may include HTML links to additional
        /// content with more information about a parameter.
        /// </summary>
        public String helpText { get; set; }

        /// <summary>
        /// Label that helps the user to identify a parameter
        /// </summary>
        public String label { get; set; }

        /// <summary>
        /// A help url that provides more information about the parameter
        /// </summary>
        public String helpUrl { get; set; }

        /// <summary>
        /// If the parameter is of enumeration data type, then this list will be populated with all of the possible enumeration values.
        /// </summary>
        public List<String> values { get; set; }

        /// <summary>
        /// The unit of measurement type of the parameter
        /// </summary>
        public String measurementType { get; set; }


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
