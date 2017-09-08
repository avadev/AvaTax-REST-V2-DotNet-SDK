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
    /// Represents a tax subtype
    /// </summary>
    public class TaxSubTypeModel
    {
        /// <summary>
        /// The unique ID number of this tax sub-type.
        /// </summary>
        public Int32 id { get; set; }

        /// <summary>
        /// The unique human readable Id of this tax sub-type.
        /// </summary>
        public String taxSubType { get; set; }

        /// <summary>
        /// The description of this tax sub-type.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// The upper level group of tax types.
        /// </summary>
        public String taxTypeGroup { get; set; }


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
