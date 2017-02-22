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
    /// A model for return augmentations.
    /// </summary>
    public class FilingAugmentationModel
    {
        /// <summary>
        /// The unique ID number for the augmentation.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The field amount.
        /// </summary>
        public Decimal fieldAmount { get; set; }

        /// <summary>
        /// The field name.
        /// </summary>
        public String fieldName { get; set; }


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
