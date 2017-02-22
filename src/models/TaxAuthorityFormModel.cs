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
    /// Represents a form that can be filed with a tax authority.
    /// </summary>
    public class TaxAuthorityFormModel
    {
        /// <summary>
        /// The unique ID number of the tax authority.
        /// </summary>
        public Int32 taxAuthorityId { get; set; }

        /// <summary>
        /// The form name of the form for this tax authority.
        /// </summary>
        public String formName { get; set; }


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
