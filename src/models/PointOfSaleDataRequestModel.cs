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
    /// Point-of-Sale Data Request Model
    /// </summary>
    public class PointOfSaleDataRequestModel
    {
        /// <summary>
        /// A unique code that references a company within your account.
        /// </summary>
        public String companyCode { get; set; }

        /// <summary>
        /// The date associated with the response content. Default is current date. This field can be used to backdate or postdate the response content.
        /// </summary>
        public DateTime? documentDate { get; set; }

        /// <summary>
        /// The format of your response. Formats include JSON, CSV, and XML.
        /// </summary>
        public PointOfSaleFileType? responseType { get; set; }

        /// <summary>
        /// A list of tax codes to include in this point-of-sale file. If no tax codes are specified, response will include all distinct tax codes associated with the Items within your company.
        /// </summary>
        public List<String> taxCodes { get; set; }

        /// <summary>
        /// A list of item codes to include in this point-of-sale file. If no item codes are specified, responese will include all distinct item codes associated with the Items within your company.
        /// </summary>
        public List<String> itemCodes { get; set; }

        /// <summary>
        /// A list of location codes to include in this point-of-sale file. If no location codes are specified, response will include all locations within your company.
        /// </summary>
        public List<String> locationCodes { get; set; }

        /// <summary>
        /// Set this value to true to include Juris Code in the response.
        /// </summary>
        public Boolean? includeJurisCodes { get; set; }

        /// <summary>
        /// A unique code assoicated with the Partner you may be working with. If you are not working with a Partner or your Partner has not provided you an ID, leave null.
        /// </summary>
        public PointOfSalePartnerId? partnerId { get; set; }


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
