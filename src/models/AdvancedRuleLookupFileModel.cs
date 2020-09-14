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
    /// Model representing a lookup file for a company
    /// </summary>
    public class AdvancedRuleLookupFileModel
    {
        /// <summary>
        /// LookupFile unique identifier
        /// </summary>
        public String lookupFileId { get; set; }

        /// <summary>
        /// CompanyLookupFile unique identifier
        /// </summary>
        public String id { get; set; }

        /// <summary>
        /// Name of lookup file
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Content of the lookup file.
        /// </summary>
        public Byte content { get; set; }

        /// <summary>
        /// File extension (e.g. CSV).
        /// </summary>
        public String fileExtension { get; set; }

        /// <summary>
        /// Is this a lookup file created for testing
        /// </summary>
        public Boolean? isTest { get; set; }

        /// <summary>
        /// Is this a lookup file in use for any rule
        /// </summary>
        public Boolean? inUse { get; set; }

        /// <summary>
        /// Lookup file version
        /// </summary>
        public Int32? version { get; set; }

        /// <summary>
        /// Lookup file CreatedDate
        /// </summary>
        public String createdDate { get; set; }

        /// <summary>
        /// Lookup file ModifiedDate
        /// </summary>
        public String modifiedDate { get; set; }


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
