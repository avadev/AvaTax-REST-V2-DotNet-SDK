using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents one file in a batch upload.
    /// </summary>
    public class BatchFileModel
    {
        /// <summary>
        /// The unique ID number assigned to this batch file.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The unique ID number of the batch that this file belongs to.
        /// </summary>
        public Int32? batchId { get; set; }

        /// <summary>
        /// Logical Name of file (e.g. "Input" or "Error").
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Content of the batch file.
        /// </summary>
        public Byte[] content { get; set; }

        /// <summary>
        /// Size of content, in bytes.
        /// </summary>
        public Int32? contentLength { get; set; }

        /// <summary>
        /// Content mime type (e.g. text/csv). This is used for HTTP downloading.
        /// </summary>
        public String contentType { get; set; }

        /// <summary>
        /// File extension (e.g. CSV).
        /// </summary>
        public String fileExtension { get; set; }

        /// <summary>
        /// Number of errors that occurred when processing this file.
        /// </summary>
        public Int32? errorCount { get; set; }


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
