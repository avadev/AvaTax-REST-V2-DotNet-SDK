using System;
using System.Collections.Generic;
using System.Text;

namespace Avalara.AvaTax.RestClient
{
    public enum LogEntryLevel
    {
        /// <summary>
        /// The log entry contains general information about a request
        /// </summary>
        Information = 1,

        /// <summary>
        /// The log entry contains information about an error that occurred during a request. 
        /// </summary>
        Error = 2
    } 
}
