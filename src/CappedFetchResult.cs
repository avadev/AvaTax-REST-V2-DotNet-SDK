using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a result set fetched from AvaTax
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CappedFetchResult<T>
    {
        /// <summary>
        /// The number of rows returned by your query, prior to pagination.
        /// </summary>
        [JsonProperty("@recordsetCount")]
        public int count { get; set; }

        /// <summary>
        /// The paginated and filtered list of records matching the parameters you supplied.
        /// </summary>
        public List<T> value { get; set; }

        /// <summary>
        /// The link to the next page of results
        /// </summary>
        [JsonProperty("@nextLink")]
        public string nextLink { get; set; }

        /// <summary>
        /// Simple Constructor
        /// </summary>
        public CappedFetchResult()
        {
            value = new List<T>();
            count = 0;
        }

        /// <summary>
        /// Construct this from a different CappedFetchResult, but maintain the count
        /// </summary>
        public CappedFetchResult(int originalRowCount, List<T> newlist)
        {
            this.count = originalRowCount;
            this.value = newlist;
        }

        /// <summary>
        /// Converts the result set to a printable text object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CappedFetchResult {\n");
            sb.Append("  count: ").Append(count).Append("\n");
            sb.Append("  value: [").Append("\n");
            foreach (var obj in value)
            {
                sb.Append("    ").Append(obj).Append("\n");
            }
            sb.Append("  ]").Append("\n");
            sb.Append("  @nextLink: ").Append(nextLink).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
