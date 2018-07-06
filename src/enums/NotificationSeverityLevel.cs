using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
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
    /// Severity level of a notification.
    /// </summary>
    public enum NotificationSeverityLevel
    {
        /// <summary>
        /// Low priority notification, Default.
        /// </summary>
        Neutral,

        /// <summary>
        /// Medium priority notification.
        /// </summary>
        Advisory,

        /// <summary>
        /// High priority notification.
        /// </summary>
        Blocking,

        /// <summary>
        /// A completed notification
        /// </summary>
        Complete,

    }
}
