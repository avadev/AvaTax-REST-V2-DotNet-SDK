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
    /// Represents classification details model
    /// </summary>
    public class ClassificationDetailsModel
    {
        /// <summary>
        /// The number of items which are classified
        /// </summary>
        public Int32? classified { get; set; }

        /// <summary>
        /// The number of items which are in progress state
        /// </summary>
        public Int32? inProgress { get; set; }

        /// <summary>
        /// The number of items which are not classified
        /// </summary>
        public Int32? notClassified { get; set; }

        /// <summary>
        /// The number of items which are failed because of some error
        /// </summary>
        public Int32? failed { get; set; }

        /// <summary>
        /// The number of items which are not found as they may be deleted
        /// </summary>
        public Int32? notFound { get; set; }


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
