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
    /// An extra property that can change the behavior of tax transactions.
    /// </summary>
    public class ParameterModel
    {
        /// <summary>
        /// The unique ID number of this property.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 07/25/2018, Version: 18.7, Message: This field is deprecated and will return null.
        /// The category grouping of this parameter. When your user interface displays a large number of parameters, they should
        /// be grouped by their category value.
        /// </summary>
        public String category { get; set; }

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
        /// A list of service types to which this parameter applies.
        /// </summary>
        public List<String> serviceTypes { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 07/25/2018, Version: 18.7, Message: This field is deprecated and will return null.
        /// The prompt you should use when displaying this parameter to a user. For example, if your user interface displays a
        /// parameter in a text box, this is the label you should use to identify that text box.
        /// </summary>
        public String prompt { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 07/25/2018, Version: 18.7, Message: This field is deprecated and will return null.
        /// If your user interface permits client-side validation of parameters, this string is a regular expression you can use
        /// to validate the user's data entry prior to submitting a tax request.
        /// </summary>
        public String regularExpression { get; set; }

        /// <summary>
        /// Label that helps the user to identify a parameter
        /// </summary>
        public String label { get; set; }

        /// <summary>
        /// A help url that provides more information about the parameter
        /// </summary>
        public String helpUrl { get; set; }

        /// <summary>
        /// The type of parameter as determined by its application, e.g. Product, Transaction, Calculated
        /// </summary>
        public String attributeType { get; set; }

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
