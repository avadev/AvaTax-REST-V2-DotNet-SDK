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
 * Swagger name: AvaTaxClient
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a language-specific localized name of a particular geographic entity such
    /// as a country or a region.
    /// </summary>
    public class IsoLocalizedName
    {
        /// <summary>
        /// The two-character alphanumeric code identifying the language in which this name is used.
        ///  
        /// Note that languageAlpha2Code and language3AlphaCode refer to the same language.
        /// </summary>
        public String languageAlpha2Code { get; set; }

        /// <summary>
        /// The three-character alphanumeric code identifying the language in which this name is used.
        ///  
        /// Note that languageAlpha2Code and language3AlphaCode refer to the same language.
        /// </summary>
        public String languageAlpha3Code { get; set; }

        /// <summary>
        /// The name of this geographic entity as known in this language.
        /// </summary>
        public String name { get; set; }


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
