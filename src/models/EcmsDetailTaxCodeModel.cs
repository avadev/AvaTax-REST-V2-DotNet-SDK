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
    /// 
    /// </summary>
    public class EcmsDetailTaxCodeModel
    {
        /// <summary>
        /// Id of the exempt certificate detail tax code
        /// </summary>
        public Int32? exemptCertDetailTaxCodeId { get; set; }

        /// <summary>
        /// exempt certificate detail id
        /// </summary>
        public Int32? exemptCertDetailId { get; set; }

        /// <summary>
        /// tax code id
        /// </summary>
        public Int32? taxCodeId { get; set; }


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
