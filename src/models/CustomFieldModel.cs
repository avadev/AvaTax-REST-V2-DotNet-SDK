using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2023 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Jonathan Wenger <jonathan.wenger@avalara.com>
 * @author Sachin Baijal <sachin.baijal@avalara.com>
 * Swagger name: AvaTaxClient
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// A custom field provides extra information about a customer or certificate.
    ///  
    /// Custom fields are provided to permit you to store additional information about an exemption certificate or customer. They are available to
    /// support additional use cases beyond that supported directly by Avalara's exemption certificate software.
    ///  
    /// For more information about custom fields, see the [Avalara Help Center article about custom fields](https://help.avalara.com/0021_Avalara_CertCapture/All_About_CertCapture/Edit_or_Remove_Details_about_Customers).
    /// </summary>
    public class CustomFieldModel
    {
        /// <summary>
        /// Custom field ID
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The name of the custom field.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Custom field type
        /// </summary>
        public String type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String possibleValues { get; set; }

        /// <summary>
        /// Custom field uses data entry or not?
        /// </summary>
        public Boolean? usesDataEntry { get; set; }

        /// <summary>
        /// Custom field is required in data entry or not?
        /// </summary>
        public Boolean? requiredInDataEntry { get; set; }

        /// <summary>
        /// The value of the custom field.
        /// </summary>
        public String value { get; set; }


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
