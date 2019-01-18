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
    /// An abridged item model used for syncing product catalogs with AvaTax.
    /// </summary>
    public class ItemSyncModel
    {
        /// <summary>
        /// A unique code representing this item.
        /// </summary>
        public String itemCode { get; set; }

        /// <summary>
        /// A friendly description of the item. If your company has enrolled in Streamlined Sales Tax, this description must be auditable.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// A group to which the item belongs.
        /// </summary>
        public String itemGroup { get; set; }

        /// <summary>
        /// The tax code of the item (optional)
        /// </summary>
        public String taxCode { get; set; }


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
