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
    /// Information about a physical area or zone in which a certificate can apply.
    /// An exposure zone for an exemption certificate will generally be a tax authority such
    /// as a state, country, or local government entity.
    /// </summary>
    public class ExposureZoneModel
    {
        /// <summary>
        /// A unique ID number representing this exposure zone.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The unique ID number of the AvaTax company that recorded this customer.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// The short name of this exposure zone, suitable for use in a drop-down list.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// A tag indicating
        /// </summary>
        public String tag { get; set; }

        /// <summary>
        /// A more complete description of this exposure zone, suitable for use as a tooltip or help text.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// The date when this record was created.
        /// </summary>
        public DateTime? created { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime? modified { get; set; }

        /// <summary>
        /// Two or three character ISO 3166 region, province, or state name of this exposure zone.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// Two character ISO 3166 county code for the country component of this exposure zone.
        /// </summary>
        public String country { get; set; }


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
