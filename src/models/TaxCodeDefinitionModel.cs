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
    /// Represents an Avalara-supported system tax code as returned by the ListTaxCodes definitions API.
    /// Extends Avalara.AvaTax.AccountServices.Models.v2.TaxCodeModel with fields that are exposed only on `GET /api/definitions/taxcodes`.
    /// </summary>
    public class TaxCodeDefinitionModel
    {
        /// <summary>
        /// The unique ID number of this tax code.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The unique ID number of the company that owns this tax code.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// A code string that identifies this tax code.
        /// </summary>
        public String taxCode { get; set; }

        /// <summary>
        /// The type of this tax code.
        /// </summary>
        public String taxCodeTypeId { get; set; }

        /// <summary>
        /// A friendly description of this tax code.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// If this tax code is a subset of a different tax code, this identifies the parent code.
        /// </summary>
        public String parentTaxCode { get; set; }

        /// <summary>
        /// True if this tax code type refers to a physical object. Read only field.
        /// </summary>
        public Boolean? isPhysical { get; set; }

        /// <summary>
        /// The Avalara Goods and Service Code represented by this tax code.
        /// </summary>
        public Int64? goodsServiceCode { get; set; }

        /// <summary>
        /// The Avalara Entity Use Code represented by this tax code.
        /// </summary>
        public String entityUseCode { get; set; }

        /// <summary>
        /// True if this tax code is active and can be used in transactions.
        /// </summary>
        public Boolean? isActive { get; set; }

        /// <summary>
        /// True if this tax code has been certified by the Streamlined Sales Tax governing board.
        /// By default, you should leave this value empty.
        /// </summary>
        public Boolean? isSSTCertified { get; set; }

        /// <summary>
        /// The date when this record was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The User ID of the user who created this record.
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// The user ID of the user who last modified this record.
        /// </summary>
        public Int32? modifiedUserId { get; set; }

        /// <summary>
        /// The vertical market / category this tax code belongs to, for example "Medical care".
        /// Null when the tax code is not classified in Content Studio.
        /// </summary>
        public String category { get; set; }

        /// <summary>
        /// The sub-category within Avalara.AvaTax.AccountServices.Models.v2.TaxCodeDefinitionModel.category, for example "Diabetic medical supplies".
        /// Null when the tax code is not classified in Content Studio.
        /// </summary>
        public String subCategory { get; set; }

        /// <summary>
        /// True if this tax code has associated parameters, so a caller knows a follow-up ListParameterUsage
        /// call is worthwhile. Read only field.
        /// </summary>
        public Boolean? hasParameters { get; set; }


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
