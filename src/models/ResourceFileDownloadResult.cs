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
    /// Represents everything downloaded from resource files
    /// </summary>
    public class ResourceFileDownloadResult
    {
        /// <summary>
        /// True if this download succeeded
        /// </summary>
        public Boolean? success { get; set; }

        /// <summary>
        /// Bytes of the file
        /// </summary>
        public Byte[] bytes { get; set; }

        /// <summary>
        /// Original filename
        /// </summary>
        public String filename { get; set; }

        /// <summary>
        /// Mime content type
        /// </summary>
        public String contentType { get; set; }


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
