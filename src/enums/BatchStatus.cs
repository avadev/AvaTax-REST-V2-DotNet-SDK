using System;

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
    /// The status of a batch file
    /// </summary>
    public enum BatchStatus
    {
        /// <summary>
        /// Batch file has been received and is in the queue to be processed.
        /// </summary>
        Waiting = 0,

        /// <summary>
        /// Batch file experienced system errors and cannot be processed.
        /// </summary>
        SystemErrors = 1,

        /// <summary>
        /// Batch file is cancelled
        /// </summary>
        Cancelled = 2,

        /// <summary>
        /// Batch file has been completely processed.
        /// </summary>
        Completed = 3,

        /// <summary>
        /// Batch file is currently being created.
        /// </summary>
        Creating = 4,

        /// <summary>
        /// Batch file has been deleted.
        /// </summary>
        Deleted = 5,

        /// <summary>
        /// Batch file was processed with some errors.
        /// </summary>
        Errors = 6,

        /// <summary>
        /// Batch processing was paused.
        /// </summary>
        Paused = 7,

        /// <summary>
        /// Batch is currently being processed.
        /// </summary>
        Processing = 8,

    }
}
