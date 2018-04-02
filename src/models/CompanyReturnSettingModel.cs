using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
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
    /// 
    /// </summary>
    public class CompanyReturnSettingModel
    {
        /// <summary>
        /// The unique ID of this CompanyReturnsSetting
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The CompanyReturn Id
        /// </summary>
        public Int64 companyReturnId { get; set; }

        /// <summary>
        /// The TaxFormCatalog filingQuestionId.
        /// </summary>
        public Int64 filingQuestionId { get; set; }

        /// <summary>
        /// Filing question code as defined in TaxFormCatalog.
        /// </summary>
        public String filingQuestionCode { get; set; }

        /// <summary>
        /// The value of this setting
        /// </summary>
        public String value { get; set; }

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
