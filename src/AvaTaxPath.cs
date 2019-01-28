using System;
using System.Collections.Generic;
using System.Text;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Build a URL including variables in paths and query strings
    /// </summary>
    /// <remarks>
    /// Since this feature is not consistently available throughout C# / DOTNET versions, this is a cross-version compatibility feature.
    /// </remarks>
    public class AvaTaxPath
    {
        private string _uri;
        private Dictionary<string, string> _fields = new Dictionary<string, string>();
        private Dictionary<string, string> _query = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        
        /// <summary>
        /// Construct a base path
        /// </summary>
        /// <param name="uri"></param>
        public AvaTaxPath(string uri)
        {
            _uri = uri;
        }

        /// <summary>
        /// Apply a variable in the path
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void ApplyField(string name, object value)
        {
            if (value != null) {
                _fields[name] = System.Uri.EscapeDataString(value.ToString());
            }
        }

        /// <summary>
        /// Apply a variable in the path
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void AddQuery(string name, object value)
        {
            if (value != null) {
                _query[System.Uri.EscapeDataString(name)] = System.Uri.EscapeDataString(value.ToString());
            }
        }

        /// <summary>
        /// Convert this to a string for use in a REST call
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder path = new StringBuilder();
            path.Append(_uri);
            foreach (var kvp in _fields) {
                path.Replace("{" + kvp.Key + "}", kvp.Value);
            }
            if (_query.Count > 0) {
                path.Append("?");
                foreach (var kvp in _query) {
                    path.AppendFormat("{0}={1}&", kvp.Key, kvp.Value);
                }
                path.Length -= 1;
            }
            return path.ToString();
        }
    }
}
