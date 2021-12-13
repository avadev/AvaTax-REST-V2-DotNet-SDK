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
    /// Replace an existing MultiDocument transaction recorded in AvaTax with a new one.
    /// </summary>
    public class AdjustMultiDocumentModel
    {
        /// <summary>
        /// A reason code indicating why this adjustment was made
        /// </summary>
        public AdjustmentReason adjustmentReason { get; set; }

        /// <summary>
        /// If the AdjustmentReason is "Other", specify the reason here.
        ///  
        /// This is required when the AdjustmentReason is 8 (Other).
        /// </summary>
        public String adjustDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CreateMultiDocumentModel newTransaction { get; set; }


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
