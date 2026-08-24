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
    /// Metadata for a parameter (attribute) a UnitOfBasis uses for tax calculation, sourced from the
    /// parameter dictionary. Provided for every attribute present in the dictionary, including
    /// engine-derived ("Calculated") attributes such as Qty.
    /// </summary>
    public class ParameterMetadataModel
    {
        /// <summary>
        /// The parameter name, matching an entry in the owning UnitOfBasis attributesUsed list.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The expected data type of the parameter value (e.g. NumericMeasured, Boolean, Enumeration).
        /// </summary>
        public String dataType { get; set; }

        /// <summary>
        /// A human-readable label for the parameter.
        /// </summary>
        public String label { get; set; }

        /// <summary>
        /// Descriptive help text for the parameter.
        /// </summary>
        public String helpText { get; set; }

        /// <summary>
        /// The attribute type (e.g. Product, Company, Transaction, Nexus).
        /// </summary>
        public String attributeType { get; set; }

        /// <summary>
        /// The measurement type code for the parameter (e.g. Quantity), when applicable.
        /// </summary>
        public String measurementType { get; set; }

        /// <summary>
        /// Whether the parameter is currently active.
        /// </summary>
        public Boolean? isActive { get; set; }

        /// <summary>
        /// Whether the parameter is needed for calculation.
        /// </summary>
        public Boolean? isNeededForCalculation { get; set; }


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
