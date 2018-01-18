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
    /// Represents information about a tax form known to Avalara
    /// </summary>
    public class AvaFileFormModel
    {
        /// <summary>
        /// Unique Id of the form
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// Name of the file being returned
        /// </summary>
        public String returnName { get; set; }

        /// <summary>
        /// Name of the submitted form
        /// </summary>
        public String formName { get; set; }

        /// <summary>
        /// A description of the submitted form
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// The date this form starts to take effect
        /// </summary>
        public DateTime? effDate { get; set; }

        /// <summary>
        /// The date the form finishes to take effect
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// State/Province/Region where the form is submitted for
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// The country this form is submitted for
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The type of the form being submitted
        /// </summary>
        public Byte? formTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Byte? filingOptionTypeId { get; set; }

        /// <summary>
        /// The type of the due date
        /// </summary>
        public Byte? dueDateTypeId { get; set; }

        /// <summary>
        /// Due date
        /// </summary>
        public Byte? dueDay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Byte? efileDueDateTypeId { get; set; }

        /// <summary>
        /// The date by when the E-filing should be submitted
        /// </summary>
        public Byte? efileDueDay { get; set; }

        /// <summary>
        /// The time of day by when the E-filing should be submitted
        /// </summary>
        public DateTime? efileDueTime { get; set; }

        /// <summary>
        /// Whether the customer has discount
        /// </summary>
        public Boolean? hasVendorDiscount { get; set; }

        /// <summary>
        /// The way system does the rounding
        /// </summary>
        public Byte? roundingTypeId { get; set; }


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
