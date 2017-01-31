using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
