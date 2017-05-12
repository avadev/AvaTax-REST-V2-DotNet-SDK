using System;
using System.Collections.Generic;
using System.Text;
#if PORTABLE
using System.Threading.Tasks;
using System.Linq;
#endif

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Track time spent on an API call
    /// </summary>
    public class CallDuration
    {
        /// <summary>
        /// Tracks the amount of time spent setting up a REST API call
        /// </summary>
        public TimeSpan SetupDuration { get; set; }

        /// <summary>
        /// Tracks the amount of time the server took processing the request
        /// </summary>
        public TimeSpan ServerDuration { get; set; }

        /// <summary>
        /// Tracks the amount of time the API call was in flight
        /// </summary>
        public TimeSpan TransitDuration { get; set; }

        /// <summary>
        /// Tracks the amount of time it took to parse results from the API call
        /// </summary>
        public TimeSpan ParseDuration { get; set; }

#region Implementation
        /// <summary>
        /// Constructor
        /// </summary>
        public CallDuration()
        {
            _checkpoint = DateTime.UtcNow;
        }

        /// <summary>
        /// Add another call's duration time to ours
        /// </summary>
        /// <param name="otherDuration"></param>
        public void Combine(CallDuration otherDuration)
        {
            SetupDuration += otherDuration.SetupDuration;
            ServerDuration += otherDuration.ServerDuration;
            TransitDuration += otherDuration.TransitDuration;
            ParseDuration += otherDuration.ParseDuration;
        }

        /// <summary>
        /// Call this when the API has finished setting up and is about to transmit
        /// </summary>
        public void FinishSetup()
        {
            SetupDuration = Checkpoint();
        }

        /// <summary>
        /// Call this when the API call has returned all its results
        /// </summary>
        public void FinishReceive(TimeSpan serverDuration)
        {
            var ts = Checkpoint();
            ServerDuration = serverDuration;
            TransitDuration = ts - serverDuration;
        }

        /// <summary>
        /// Call this when the results have been fully parsed
        /// </summary>
        public void FinishParse()
        {
            ParseDuration = Checkpoint();
        }

        /// <summary>
        /// Print out call duration in a friendly manner
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Setup: {SetupDuration} Server: {ServerDuration} Transit: {TransitDuration} Parse: {ParseDuration}";
        }

        /// <summary>
        /// Keep track of time since last checkpoint
        /// </summary>
        private DateTime _checkpoint;

        /// <summary>
        /// Determine time since last checkpoint, and advance checkpoint
        /// </summary>
        /// <returns></returns>
        private TimeSpan Checkpoint()
        {
            var newCheckpoint = DateTime.UtcNow;
            var ts = newCheckpoint - _checkpoint;
            _checkpoint = newCheckpoint;
            return ts;
        }
#endregion
    }
}
