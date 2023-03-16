using System;

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
    /// Severity level of a notification.
    /// </summary>
    public enum NotificationSeverityLevel
    {
        /// <summary>
        /// Low priority notification, Default.
        /// </summary>
        Neutral = 0,

        /// <summary>
        /// Medium priority notification.
        /// </summary>
        Advisory = 1,

        /// <summary>
        /// High priority notification.
        /// </summary>
        Blocking = 2,

        /// <summary>
        /// A completed notification
        /// </summary>
        Complete = -1,

    }
}
