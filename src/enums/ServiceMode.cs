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
    /// Service modes for tax calculation when using an AvaLocal server.
    /// </summary>
    public enum ServiceMode
    {
        /// <summary>
        /// Automatically use local or remote (default)
        /// </summary>
        Automatic = 0,

        /// <summary>
        /// Local server only
        /// </summary>
        Local = 1,

        /// <summary>
        /// Remote server only
        /// </summary>
        Remote = 2,

    }
}
