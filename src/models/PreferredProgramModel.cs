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
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// A preferred program is a customs and/or duty program that can be used to handle cross-border transactions.
    /// Customers who sign up for a preferred program may obtain better terms for their customs and duty payments.
    /// 
    /// To indicate that your company has signed up for a preferred program, specify the `code` value from this
    /// object as the value for the `AvaTax.LC.PreferredProgram` parameter in your transaction.
    /// </summary>
    public class PreferredProgramModel
    {
        /// <summary>
        /// The unique ID number representing this preferred program.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// A code that identifies this preferred program. To select this program, specify this code
        /// value in the `AvaTax.LC.PreferredProgram` parameter.
        /// </summary>
        public String code { get; set; }

        /// <summary>
        /// The ISO 3166 country code for the origin permitted by this program
        /// </summary>
        public String originCountry { get; set; }

        /// <summary>
        /// The ISO 3166 country code for the destination permitted by this program
        /// </summary>
        public String destinationCountry { get; set; }

        /// <summary>
        /// The earliest date for which this preferred program can be used in AvaTax. If `null`, this preferred program
        /// is valid for all dates earlier than `endDate`.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// The latest date for which this preferred program can be used in AvaTax. If `null`, this preferred program
        /// is valid for all dates later than `effectiveDate`.
        /// </summary>
        public DateTime? endDate { get; set; }


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
