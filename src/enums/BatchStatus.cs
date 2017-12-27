using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
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
        Waiting,

        /// <summary>
        /// Batch file experienced system errors and cannot be processed.
        /// </summary>
        SystemErrors,

        /// <summary>
        /// Batch file is cancelled
        /// </summary>
        Cancelled,

        /// <summary>
        /// Batch file has been completely processed.
        /// </summary>
        Completed,

        /// <summary>
        /// Batch file is currently being created.
        /// </summary>
        Creating,

        /// <summary>
        /// Batch file has been deleted.
        /// </summary>
        Deleted,

        /// <summary>
        /// Batch file was processed with some errors.
        /// </summary>
        Errors,

        /// <summary>
        /// Batch processing was paused.
        /// </summary>
        Paused,

        /// <summary>
        /// Batch is currently being processed.
        /// </summary>
        Processing,

    }
}
