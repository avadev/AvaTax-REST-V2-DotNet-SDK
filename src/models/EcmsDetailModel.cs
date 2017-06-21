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
    public class EcmsDetailModel
    {
        /// <summary>
        /// detail id
        /// </summary>
        public Int32 exemptCertDetailId { get; set; }

        /// <summary>
        /// exempt certificate id
        /// </summary>
        public Int32 exemptCertId { get; set; }

        /// <summary>
        /// State FIPS
        /// </summary>
        public String stateFips { get; set; }

        /// <summary>
        /// Region or State
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// ID number
        /// </summary>
        public String idNo { get; set; }

        /// <summary>
        /// Country that this exempt certificate is for
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// End date of this exempt certificate
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// ID type of this exempt certificate
        /// </summary>
        public String idType { get; set; }

        /// <summary>
        /// Is the tax code list an exculsion list?
        /// </summary>
        public Byte? isTaxCodeListExclusionList { get; set; }

        /// <summary>
        /// optional: list of tax code associated with this exempt certificate detail
        /// </summary>
        public List<EcmsDetailTaxCodeModel> taxCodes { get; set; }


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
