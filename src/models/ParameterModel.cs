using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
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
    /// An extra property that can change the behavior of tax transactions.
    /// </summary>
    public class ParameterModel
    {
        /// <summary>
        /// The unique ID number of this property.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
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
        public ParameterBagDataType? dataType { get; set; }

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
        /// The prompt you should use when displaying this parameter to a user. For example, if your user interface displays a
        /// parameter in a text box, this is the label you should use to identify that text box.
        /// </summary>
        public String prompt { get; set; }

        /// <summary>
        /// If your user interface permits client-side validation of parameters, this string is a regular expression you can use
        /// to validate the user's data entry prior to submitting a tax request.
        /// </summary>
        public String regularExpression { get; set; }


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
