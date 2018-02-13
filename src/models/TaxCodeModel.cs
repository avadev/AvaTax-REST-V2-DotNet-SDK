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
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a tax code that can be applied to items on a transaction.
    /// A tax code can have specific rules for specific jurisdictions that change the tax calculation behavior.
    /// </summary>
    public class TaxCodeModel
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
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
