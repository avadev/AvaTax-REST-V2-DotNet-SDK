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
        /// The service category of this property. Some properties may require that you subscribe to certain features of avatax before they can be used.
        /// </summary>
        public String category { get; set; }

        /// <summary>
        /// The name of the property. To use this property, add a field on the "properties" object of a /api/v2/companies/(code)/transactions/create call.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The data type of the property.
        /// </summary>
        public ParameterBagDataType? dataType { get; set; }

        /// <summary>
        /// A full description of this property.
        /// </summary>
        public String description { get; set; }


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
